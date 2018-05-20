using System;
using System.Collections.Generic;
using System.Text;

namespace LibToBenchmark
{
	public class HistoricalValue
	{
		public DateTime Date { get; set; }

		private decimal open;
		public Decimal Open
		{
			get { return Math.Round(open, 2); }
			set { open = value; }
		}

		private decimal high;
		public Decimal High
		{
			get { return Math.Round(high, 2); }
			set { high = value; }
		}

		private decimal low;
		public Decimal Low
		{
			get { return Math.Round(low, 2); }
			set { low = value; }
		}

		private decimal close;

		public Decimal Close
		{
			get { return Math.Round(close, 2); }
			set { close = value; }
		}

		public long Volume { get; set; }
	}
}
