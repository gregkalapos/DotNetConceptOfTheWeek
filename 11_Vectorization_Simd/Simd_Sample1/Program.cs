using System;
using System.Numerics;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Simd_Sample1
{
	[DisassemblyDiagnoser(printAsm: true, printSource: true, printIL: true)]
	public class Program
	{
		static void Main(string[] args)
		{
			//var summary = BenchmarkRunner.Run<Program>();
			AddArrays_Vector(v1, v2);
		}

		[Benchmark]
		public static void AddArrays_Simple_Benchmark()
		{
			AddArrays_Simple(v1, v2);
		}

		[Benchmark]
		public static void AddArrays_Vector_Benchmark()
		{
			AddArrays_Vector(v1, v2);
		}

		public static double[] AddArrays_Vector(double[] v1, double[] v2)
		{
			double[] retVal = new double[v1.Length];
			var vectSize = Vector<decimal>.Count;

			int i = 0;
			for (i = 0; i < v1.Length - vectSize; i += vectSize)
			{
				var va = new Vector<double>(v1, i);
				var vb = new Vector<double>(v2, i);
				var vc = va + vb;
				vc.CopyTo(retVal, i);
			}

			if (i != v1.Length)
			{
				for (int j = i; j < v1.Length; j++)
				{
					retVal[j] = v1[j] + v2[j];
				}
			}

			return retVal;
		}

		public static double[] AddArrays_Simple(double[] v1, double[] v2)
		{
			double[] retVal = new double[v1.Length];

			for (int i = 0; i < v1.Length; i++)
			{
				retVal[i] = v1[i] + v2[i];
			}

			return retVal;
		}

		static double[] v1 = new double[]
{
			33,
			35,
			45,
			63,
			72,
			47,
			33,
			36,
			45,
			65,
			72,
			27,
			33,
			35,
			45,
			63,
			72,
			47,
			33,
			36,
			45,
			65,
			72,
			27,
			33,
			35,
			45,
			63,
			72,
			47,
			33,
			36,
			45,
			65,
			72,
			27,
			33,
			35,
			45,
			63,
			72,
			47,
			33,
			36,
			45,
			65,
			72,
			27,
			33,
			35,
			45,
			63,
			72,
			47,
			33,
			36,
			45,
			65,
			72,
			27,
			33,
			35,
			45,
			63,
			72,
			47,
			33,
			36,
			45,
			65,
			72,
			27,
			33,
			35,
			45,
			63,
			72,
			47,
			33,
			36,
			45,
			65,
			72,
			27,
			33,
			35,
			45,
			63,
			72,
			47,
			33,
			86,
			45,
			65,
			74,
			27,
			33,
			55,
			45,
			63,
			72,
			47,
			33,
			36,
			45,
			65,
			82,
			27,
			33,
			85,
			15,
			63,
			72,
			47,
			33,
			96,
			45,
			63,
			72,
			17,
};
		static double[] v2 = new double[]
		{
			33,
			65,
			45,
			63,
			72,
			57,
			33,
			36,
			45,
			65,
			72,
			27,
			33,
			35,
			45,
			63,
			72,
			47,
			33,
			36,
			45,
			65,
			72,
			37,
			33,
			35,
			45,
			63,
			72,
			47,
			33,
			36,
			45,
			65,
			72,
			27,
			33,
			35,
			45,
			63,
			12,
			47,
			33,
			36,
			45,
			65,
			72,
			27,
			33,
			35,
			45,
			63,
			72,
			47,
			33,
			36,
			45,
			65,
			72,
			27,
			33,
			35,
			45,
			63,
			72,
			47,
			33,
			36,
			45,
			65,
			72,
			27,
			33,
			35,
			45,
			63,
			72,
			47,
			33,
			36,
			45,
			65,
			72,
			27,
			33,
			35,
			45,
			63,
			72,
			47,
			33,
			86,
			45,
			75,
			74,
			27,
			33,
			55,
			45,
			63,
			72,
			47,
			33,
			36,
			45,
			65,
			82,
			27,
			13,
			85,
			15,
			63,
			72,
			47,
			93,
			96,
			15,
			63,
			52,
			17,
		};
	}
}
