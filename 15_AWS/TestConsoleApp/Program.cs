using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchnitzelOrNotClient;

namespace TestConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			//NOT: wiener-schnitzel.jpg, default-img-101715.jpg,
			//YES: wiener-schnitzel (1).jpg, Wiener-Schnitzel-1A-49a1616656a6c.jpg, Schnitzel-Wiener-Art.jpg

			SchnitzelDetector schnitzelDetector = new SchnitzelDetector(); //TODO: Add secret Key
			var fileName = "Schnitzel-Wiener-Art.jpg";
			if (schnitzelDetector.IsSchnitzel(fileName , fileName).Result == true)
			{
				Console.WriteLine("This is a Schnitzel!");
			}
			else
			{
				Console.WriteLine("This is not a Schnitzel!");
			}

			Console.WriteLine("Hello World!");
			Console.ReadKey();
		}
	}
}
