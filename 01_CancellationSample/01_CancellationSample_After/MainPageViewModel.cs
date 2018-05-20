using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CancellationSample.DataAccess;
using CancellationSample.Model;

namespace CancellationSample
{
	class MainPageViewModel : INotifyPropertyChanged, IDisposable
	{
		private CancellationTokenSource _cts = new CancellationTokenSource();
		public List<TimeFrame> ChartTimeFrame { get; }

		private List<HistoricalValue> historicalPrices;
		public List<HistoricalValue> HistoricalPrices
		{
			get { return historicalPrices; }
			set
			{
				historicalPrices = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HistoricalPrices)));
			}
		}

		private TimeFrame selectedChartTimeFrame;

		public TimeFrame SelectedChartTimeFrame
		{
			get { return selectedChartTimeFrame; }
			set
			{
				selectedChartTimeFrame = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedChartTimeFrame)));
				LoadHistoricalData();
			}
		}

		public MainPageViewModel()
		{
			_cts = new CancellationTokenSource();
			ChartTimeFrame = Enum.GetValues(typeof(TimeFrame)).Cast<TimeFrame>().ToList();
			SelectedChartTimeFrame = TimeFrame.Month3;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public async Task LoadHistoricalData()
		{
			_cts.Cancel();
			_cts.Dispose();
			_cts = new CancellationTokenSource();
			try
			{
				switch (SelectedChartTimeFrame)
				{
					case TimeFrame.Day1:
						HistoricalPrices = await CryptoCurrencyDataSource.GetHistoricalDataMinutes("USD", "BTC", 1440, _cts.Token);
						break;
					case TimeFrame.Week1:
						HistoricalPrices = await CryptoCurrencyDataSource.GetHistoricalDataHourly("USD", "BTC", 168, _cts.Token);
						break;
					case TimeFrame.Month1:
						HistoricalPrices = await CryptoCurrencyDataSource.GetHistoricalDataDaily("USD", "BTC", 30, _cts.Token);
						break;
					case TimeFrame.Month2:
						HistoricalPrices = await CryptoCurrencyDataSource.GetHistoricalDataDaily("USD", "BTC", 60, _cts.Token);
						break;
					case TimeFrame.Month3:
						HistoricalPrices = await CryptoCurrencyDataSource.GetHistoricalDataDaily("USD", "BTC", 90, _cts.Token);
						break;
					case TimeFrame.Month6:
						HistoricalPrices = await CryptoCurrencyDataSource.GetHistoricalDataDaily("USD", "BTC", 180, _cts.Token);
						break;
					case TimeFrame.Year1:
						HistoricalPrices = await CryptoCurrencyDataSource.GetHistoricalDataDaily("USD", "BTC", 365, _cts.Token);
						break;
					case TimeFrame.All:
						HistoricalPrices = await CryptoCurrencyDataSource.GetAllHistoricalData("USD", "BTC", _cts.Token);
						break;
					default:
						break;
				}
			}
			catch (OperationCanceledException) { }
		}

		public void Dispose()
		{
			if (_cts != null)
			{
				_cts.Dispose();
				_cts = null;
			}
		}
	}
}
