using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace LibToBenchmark
{
    public class SimpleMovingAverage
    {
		public SimpleMovingAverage()
		{
			
		}

		public static List<Quote> CalculateSMALinq(List<HistoricalValue> Price, int SMALength)
		{
			List<Quote> retVal = new List<Quote>();
			for (int i = 0; i < Price.Count() - SMALength + 1; i++)
			{
				var firstSmaLengthItems = Price.Skip(i).Take(SMALength);
				var fistAvg = firstSmaLengthItems.Average(n => n.Close);
				retVal.Add(new Quote { Date = firstSmaLengthItems.Last().Date, Value = fistAvg });
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

				if (i >= SMALength-1)
					retVal.Add(new Quote() { Value = ma, Date = Price[i].Date });
				current_index = (current_index + 1) % SMALength;
			}
			return retVal;
		}
	}
}
