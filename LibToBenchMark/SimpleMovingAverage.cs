using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace LibToBenchmark
{
	/// <summary>
	/// We benchmark the 2 different SMA implementations from this class
	/// </summary>
	public class SimpleMovingAverage
	{
		public static List<Quote> CalculateSMALinq(List<HistoricalValue> Price, int SMALength)
		{
			List<Quote> retVal = new List<Quote>();
			for (int i = 0; i < Price.Count() - SMALength + 1; i++)
			{
				var firstSmaLengthItems = Price.Skip(i).Take(SMALength);
				var firstAvg = firstSmaLengthItems.Average(n => n.Close);
				retVal.Add(new Quote { Date = firstSmaLengthItems.Last().Date, Value = firstAvg });
			}

			return retVal;
		}

		public static List<Quote> CalculateSMA(List<HistoricalValue> Price, int SMALength)
		{
			List<Quote> retVal = new List<Quote>();
			decimal[] buffer = new decimal[SMALength];
			var current_index = 0;
			for (int i = 0; i < Price.Count; i++)
			{
				buffer[current_index] = Price[i].Close / SMALength;
				decimal ma = 0;
				for (int j = 0; j < SMALength; j++)
				{
					ma += buffer[j];
				}

				if (i >= SMALength - 1)
					retVal.Add(new Quote() { Value = ma, Date = Price[i].Date });
				current_index = (current_index + 1) % SMALength;
			}
			return retVal;
		}
	}
}
