using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoDataSourceLib
{
	public class CryptoCurrencyUpdate
    {
		public String ExchangeName { get; set; }
		public String CryptoCurrencyName { get; set; }

		public String FiatCurrencyName { get; set; }

		public decimal LastPrice { get; set; }

		public decimal Quantity { get; set; }

		public DateTime TimeSpan { get; set; }

		public decimal Total { get; set; }

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();

			sb.AppendLine($"ExchangeName:{ExchangeName}");
			sb.AppendLine($"CryptoCurrencyName:{CryptoCurrencyName}");
			sb.AppendLine($"FiatCurrencyName:{FiatCurrencyName}");
			sb.AppendLine($"LastPrice:{LastPrice}");
			sb.AppendLine($"Quantity:{Quantity}");
			sb.AppendLine($"TimeSpan:{TimeSpan}");
			sb.AppendLine($"Total:{Total}");

			return sb.ToString();
		}
	}
}
