using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs8NullableReferenceTypes
{
	class Program
	{
		static void Main(string[] args)
		{
			Person? p = null;
			if (p == null)
				return;

			Console.WriteLine(p);
		}

		public static void PrintMiddleName(Person p)
		{
			Console.WriteLine(p.MiddleName!);
		}
	}
	class Person
	{
		public Person(String firstName, String lastName)
		{
			FirstName = firstName;
			LastName = lastName;
		}
		public String FirstName { get; set; }
		public String? MiddleName { get; set; }
		public String LastName { get; set; }
	}
}
