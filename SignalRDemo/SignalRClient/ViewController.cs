using System;
using Microsoft.AspNetCore.SignalR.Client;
using UIKit;

namespace SignalRClient
{
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();

            var id = "iOS" + new Random().Next();

            var connection = new HubConnectionBuilder()
               .WithUrl("http://localhost:5000/chat")
               .WithConsoleLogger()
               .Build();

          


            connection.On<string>("Send", data =>
            {
                InvokeOnMainThread(() =>
                {
                    AllMsgs.Text += $"{data} \n";
                });
            });

            await connection.StartAsync();

            SendBtn.TouchDown += (sender, e) =>
            {
                connection.InvokeAsync("Send", $"{id}: {EnteredMsg.Text}");
                EnteredMsg.Text = String.Empty;
            };

            await connection.InvokeAsync("Send", $"{id} Connected");
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
