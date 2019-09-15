using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DiagnosticSourceSample
{
	public class MySampleLibrary
	{
		private static readonly DiagnosticSource diagnosticSource =
			new DiagnosticListener(typeof(MySampleLibrary).FullName);

		public int GetRandomNumber()
		{
			if (diagnosticSource.IsEnabled(typeof(MySampleLibrary).FullName))
			{
				diagnosticSource.Write($"{typeof(MySampleLibrary).FullName}.StartGenerateRandom", null);
			}
			var number = new Random().Next();

			if (diagnosticSource.IsEnabled(typeof(MySampleLibrary).FullName))
			{
				diagnosticSource.Write($"{typeof(MySampleLibrary).FullName}.EndGenerateRandom",
				new { RandomNumber = number });
			}

			return number;
		}

		public static async Task DoThingAsync(int id)
		{
			var activity = new Activity(nameof(DoThingAsync));

			if (diagnosticSource.IsEnabled(typeof(MySampleLibrary).FullName))
			{
				diagnosticSource.StartActivity(activity, new { IdArg = id });
			}

			activity.AddTag("MyTagId", "ValueInTags");
			activity.AddBaggage("MyBaggageId", "ValueInBaggage");

			var httpClient = new HttpClient();
			await httpClient.GetAsync("http://localhost:5000/values");

			if (diagnosticSource.IsEnabled(typeof(MySampleLibrary).FullName))
			{
				diagnosticSource.StopActivity(activity, new { IdArg = id });
			}
		}
	}
}





















