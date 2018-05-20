using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;

namespace StructLayoutSample
{
	public class Program
	{
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		struct Struct1
		{
			public byte b1;
			public double d1;
			public byte b2;
			public double d2;
			public byte b3;
		}

		class C { }
		
		struct Struct2
		{
			public double d1;
			public double d2;
			public byte b1;
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

		static void Main(string[] args)
		{
			Union u = new Union();
			u.i = 42;
			Console.WriteLine(u.boolean);
			u.boolean = false;
			int b = u.i;

			unsafe
			{
				Console.WriteLine("Union: " + sizeof(Union));
				Console.WriteLine("Struct1: " + sizeof(Struct1));
				Console.WriteLine("Struct2: " + sizeof(Struct2));
			}

			Console.ReadKey();
		}
	}
}
