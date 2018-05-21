using System;
using System.Diagnostics;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace FilterVsCatchBlockBenchmark
{
	public class Program
	{
		static void Main(string[] args)
		{
			var summary = BenchmarkRunner.Run<Program>();
		}

		[Benchmark]
		public void ExceptionsWithCatchBlock()
		{
			for (int i = 0; i < 100; i++)
			{
				try
				{
					CatchBlockImpl();
				}
				catch
				{

				}
			}
		}

		public void CatchBlockImpl()
		{			
			try
			{
				MWithException();
			}
			catch (Exception)
			{
				Debug.WriteLine("Exception catch");
				throw;
			}

		}

		[Benchmark]
		public void ExceptionsWithFilter()
		{
			for (int i = 0; i < 100; i++)
			{

				try
				{
					FilterImpl();
				}
				catch
				{

				}
			}
		}

		public void FilterImpl()
		{
			try
			{
				MWithException();
			}
			catch (Exception e) when (Log(e)){ }

			bool Log(Exception e)
			{
				Debug.WriteLine("Exception filter");
				return false;
			}
		}

		static void MWithException() => throw new Exception("Bamm");
	}
}
