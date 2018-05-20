using System;

using UIKit;

namespace _BitcoinTracker.iOS
{
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        CryptoDataSourceLib.CryptoDataSource cds;
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            cds = new CryptoDataSourceLib.CryptoDataSource();
            cds.DataRecieved += (sender, e) => {
                LastTradePriceLabel.Text = e.LastPrice.ToString();
                LastTradeExchangeLabel.Text = e.ExchangeName;
            };

            StartButton.TouchUpInside += (sender, e) => 
            {
                cds.StartLoadingData();
            };

            StopButton.TouchUpInside += (sender, e) => 
            {
                cds.StopLoadingData();
            };

            cds.StartLoadingData();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
