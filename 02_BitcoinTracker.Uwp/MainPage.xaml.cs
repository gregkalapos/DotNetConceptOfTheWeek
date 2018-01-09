using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace _02_BitcoinTracker.Uwp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
		CryptoDataSourceLib.CryptoDataSource dataSource = new CryptoDataSourceLib.CryptoDataSource();

		public MainPage()
        {
            this.InitializeComponent();

			 
			dataSource.DataRecieved += (sender, obj) =>
			{
				ExchangeTextBlock.Text = obj.ExchangeName;
				PriceTextBlock.Text = obj.LastPrice.ToString();
			};

			dataSource.StartLoadingData();
        }


		private void StartClicked(object sender, RoutedEventArgs e)
		{
			dataSource.StartLoadingData();
		}

		private void StopClicked(object sender, RoutedEventArgs e)
		{
			dataSource.StopLoadingData();
		}
	}
}
