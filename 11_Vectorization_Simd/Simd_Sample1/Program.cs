using System;
using System.Numerics;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Simd_Sample1
{
	[DisassemblyDiagnoser(printAsm: true, printSource: true, printIL: true)]
	public class Program
	{
		static int[] v1 = new int[]
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

		static int[] v2 = new int[]
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

		static void Main(string[] args)
		{
			var summary = BenchmarkRunner.Run<Program>();
		}

		[Benchmark]
		public static void AddArrays_Vector_Benchmark()
		{
			AddArrays_Vector(v1, v2);
		}

		[Benchmark]
		public static void AddArrays_Simple_Benchmark()
		{
			AddArrays_Simple(v1, v2);
		}

		public static int[] AddArrays_Vector(int[] v1, int[] v2)
		{
			int[] retVal = new int[v1.Length];
			int vecSize = Vector<int>.Count;

			int i = 0;
			for (i = 0; i < v1.Length - vecSize; i += vecSize)
			{
				var va = new Vector<int>(v1, i);
				var vb = new Vector<int>(v2, i);
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

		public static int[] AddArrays_Simple(int[] v1, int[] v2)
		{
			int[] retVal = new int[v1.Length];

			for (int i = 0; i < v1.Length; i++)
			{
				retVal[i] = v1[i] + v2[i];
			}

			return retVal;
		}
	}
}
