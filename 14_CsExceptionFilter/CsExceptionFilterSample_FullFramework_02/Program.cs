using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

namespace CsExceptionFilterSample
{

	class GetC
	{
		public static void M(Object o)
		{
			var thread = o as Thread;
			thread.Suspend();
			System.Diagnostics.StackTrace s = new StackTrace(thread, false);			
			Console.WriteLine("======StackTrace=====");
			Console.WriteLine(
			 s.ToString());
			Console.WriteLine("");
			thread.Resume();
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			var stateTimer = new Timer(GetC.M, Thread.CurrentThread, 1000, 0);
			A();
			Console.ReadKey();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static void A()
		{
			B_WithFilter();
		}

		static void B_WithFilter()
		{
			try
			{
				C();
			}
			catch (Exception e) when (Log(e)){}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static void B_WithExceptionHandler()
		{
			try
			{
				C();
			}
			catch (Exception e)
			{
				Log(e);
				throw;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static void C() {
			var dateTime = DateTime.UtcNow;
			Console.WriteLine(dateTime);
			throw new Exception("Bamm");
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static bool Log(Exception e)
		{
			Console.WriteLine($"Exception: {e.Message}");
			//Thread.Sleep(50000000);
			return false;
		}
	}
}
