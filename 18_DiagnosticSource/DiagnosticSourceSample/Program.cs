using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace DiagnosticSourceSample
{
	class Program
	{
		static async Task Main(string[] args)
		{
			Subscribe();
			await MySampleLibrary.DoThingAsync(42);
			//var number = new MySampleLibrary().GetRandomNumber();

			//var httpClient = new HttpClient();
			//await httpClient.GetAsync("https://kalapos.net");

			Console.WriteLine("Hello World!");
		}

		private static void Subscribe()
		{
			DiagnosticListener.AllListeners.Subscribe(new Subscriber());
		}
	}

	class MyLibraryListener : IObserver<KeyValuePair<string, object>>
	{
		public void OnCompleted() { }
		public void OnError(Exception error) { }

		public void OnNext(KeyValuePair<string, object> keyValue)
		{
			switch (keyValue.Key)
			{
				case "DoThingAsync.Start":
					Console.WriteLine($"DoThingAsync.Start - activity id: {Activity.Current?.Id}");
					break;
				case "DoThingAsync.Stop":
					Console.WriteLine("DoThingAsync.Stop");

					if(Activity.Current != null)
					{
						foreach (var tag in Activity.Current.Tags)
						{
							Console.WriteLine($"{tag.Key} - {tag.Value}");
						}
					}
					break;
				case "DiagnosticSourceSample.MySampleLibrary.StartGenerateRandom":
					Console.WriteLine("StartGenerateRandom");
					break;
				case "DiagnosticSourceSample.MySampleLibrary.EndGenerateRandom":
					var randomValue = keyValue.Value.GetType().GetTypeInfo().GetDeclaredProperty("RandomNumber")?.
						GetValue(keyValue.Value);

					Console.WriteLine($"StopGenerateRandom Generated random value: {randomValue}");
					break;
				default:
					break;
			}
		}
	}

	class Subscriber : IObserver<DiagnosticListener>
	{
		public void OnCompleted() { }
		public void OnError(Exception error) { }

		public void OnNext(DiagnosticListener listener)
		{
			if (listener.Name == typeof(MySampleLibrary).FullName)
			{
				listener.Subscribe(new MyLibraryListener());
			}

			if (listener.Name == "HttpHandlerDiagnosticListener")
			{
				listener.Subscribe(new HttpClientObserver());
			}
		}
	}

	class HttpClientObserver : IObserver<KeyValuePair<string, object>>
	{
		Stopwatch _stopwatch = new Stopwatch();

		public void OnCompleted() { }

		public void OnError(Exception error) { }

		public void OnNext(KeyValuePair<string, object> receivedEvent)
		{
			switch (receivedEvent.Key)
			{
				case "System.Net.Http.HttpRequestOut.Start":
					_stopwatch.Start();

					if (receivedEvent.Value.GetType().GetTypeInfo().GetDeclaredProperty("Request")
						?.GetValue(receivedEvent.Value) is HttpRequestMessage requestMessage)
					{
						Console.WriteLine($"HTTP Request start: {requestMessage.Method} -" +
							$" {requestMessage.RequestUri} - activity id: {Activity.Current.Id}, parentactivity Id: {Activity.Current.ParentId}");
					}

					break;
				case "System.Net.Http.HttpRequestOut.Stop":
					_stopwatch.Stop();

					if (receivedEvent.Value.GetType().GetTypeInfo().GetDeclaredProperty("Response")
						?.GetValue(receivedEvent.Value) is HttpResponseMessage responseMessage)
					{
						Console.WriteLine($"HTTP Request finished: took " +
							$"{_stopwatch.ElapsedMilliseconds}ms, status code:" +
								$" {responseMessage.StatusCode} - activity id: {Activity.Current.Id}, parentactivity Id: {Activity.Current.ParentId}");
					}

					break;
			}
		}
	}
}
