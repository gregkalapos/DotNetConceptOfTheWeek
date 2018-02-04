using System;
using System.Collections.Generic;
using System.Text;

namespace LibToBenchmark
{
	public class Quote
	{
		public DateTime Date { get; set; }
		public Decimal Value { get; set; }

		public Quote(DateTime date, Decimal value)
		{
			Date = date;
			Value = value;
		}

		public Quote()
		{

		}
	}

}
