using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;

namespace StructLayoutSample
{
	public class Program
	{
		struct Struct1
		{
			public byte b1;
			public double d1;
			public byte b2;
			public double d2;
			public byte b3;
		}
		
		[StructLayout(LayoutKind.Auto)]
		struct Struct2
		{
			public double d1;
			public double d2;
			public byte b1;
			public byte b2;
			public byte b3;
		}

		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		struct Struct3
		{
			public byte b1;
			public double d1;
			public double d2;
			public byte b2;
			public byte b3;
		}


		[StructLayout(LayoutKind.Explicit)]
		struct Union
		{
			[FieldOffset(0)]
			public byte b;
			[FieldOffset(0)]
			public int i;
			[FieldOffset(0)]
			public bool boolean;
		}

		class C { }

		static void Main(string[] args)
		{
			unsafe
			{
				Console.WriteLine("Struct1: " + sizeof(Struct1));
				Console.WriteLine("Struct2: " + sizeof(Struct2));
				Console.WriteLine("Struct3: " + sizeof(Struct3));

				Console.WriteLine("Union: " + sizeof(Union));
			}
			Console.ReadKey();
		}
	}
}
