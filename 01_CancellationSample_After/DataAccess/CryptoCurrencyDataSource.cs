using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CancellationSample.Model;
using Newtonsoft.Json.Linq;

namespace CancellationSample.DataAccess
{
	public static class CryptoCurrencyDataSource
	{
		public static Task<List<HistoricalValue>> GetHistoricalDataMinutes(String fiatCurrency, String cryptoCurrency, int lengthInMinutes, CancellationToken cancellationToken = default)
		{
			return GetHistoricalDataInternal($"https://min-api.cryptocompare.com/data/histominute?fsym={cryptoCurrency}&tsym={fiatCurrency}&limit={lengthInMinutes}&aggregate=1&e=CCCAGG", cancellationToken);
		}

		public static Task<List<HistoricalValue>> GetHistoricalDataHourly(String fiatCurrency, String cryptoCurrency, int lengthInHours, CancellationToken cancellationToken = default)
		{
			return GetHistoricalDataInternal($"https://min-api.cryptocompare.com/data/histohour?fsym={cryptoCurrency}&tsym={fiatCurrency}&limit={lengthInHours}&aggregate=1&e=CCCAGG", cancellationToken);
		}

		public static Task<List<HistoricalValue>> GetHistoricalDataDaily(String fiatCurrency, String cryptoCurrency, int lengthInDay, CancellationToken cancellationToken = default)
		{
			return GetHistoricalDataInternal($"https://min-api.cryptocompare.com/data/histoday?fsym={cryptoCurrency}&tsym={fiatCurrency}&limit={lengthInDay}&aggregate=1&e=CCCAGG", cancellationToken);
		}

		public static Task<List<HistoricalValue>> GetAllHistoricalData(String fiatCurrency, String cryptoCurrency, CancellationToken cancellationToken = default)
		{

			return GetHistoricalDataInternal($"https://min-api.cryptocompare.com/data/histoday?fsym={cryptoCurrency}&tsym={fiatCurrency}&allData=true&aggregate=1&e=CCCAGG", cancellationToken);
		}
		private static async Task<List<HistoricalValue>> GetHistoricalDataInternal(String url, CancellationToken cancellationToken = default)
		{
			cancellationToken.ThrowIfCancellationRequested();
			await Task.Delay(2000); //Make it slow for demo purposes 
			
			var retVal = new List<HistoricalValue>();
			HttpClient httpClient = new HttpClient();
			cancellationToken.ThrowIfCancellationRequested();
			var response = await httpClient.GetAsync(url, cancellationToken);
			cancellationToken.ThrowIfCancellationRequested();

			var stringResponse = await response.Content.ReadAsStringAsync();
			JObject resp = JObject.Parse(stringResponse);
			var arrayValues = resp["Data"].Value<JArray>();

			foreach (var item in arrayValues)
			{
				cancellationToken.ThrowIfCancellationRequested();
				var low = item["low"].Value<decimal>();
				var close = item["close"].Value<decimal>();
				var high = item["high"].Value<decimal>();
				var open = item["open"].Value<decimal>();
				var ticks = item["time"].Value<long>();
				var volume = item["volumeto"].Value<long>();
				var dateTime = DateTimeOffset.FromUnixTimeSeconds(ticks).DateTime;
				retVal.Add(new HistoricalValue
				{
					Close = close,
					Date = dateTime,
					High = high,
					Low = low,
					Open = open,
					Volume = volume
				});
			}
			return retVal;
		}
	}
}
