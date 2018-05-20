using System;
using System.Threading.Tasks;
using System.Linq;

namespace CsharpAppUsingFsharpLib
{
    class Program
    {
        static async Task Main(string[] args)
        {
			var stockData = await StockAnalyticsLib.FsStockLib.ReadCsv;
			Console.WriteLine($"# of days up: {StockAnalyticsLib.FsStockLib.NumberOfDaysInPlus(stockData)}");
			Console.WriteLine($"# of days down: {StockAnalyticsLib.FsStockLib.NumberOfDaysInNegative(stockData)}");

			var dayChanges = await StockAnalyticsLib.FsStockLib.ChangesPerDayAsync;
			Console.WriteLine(dayChanges.First().ToString());
		}
    }
}
