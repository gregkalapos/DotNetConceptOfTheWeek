using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using SchnitzelOrNotClient;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UwpSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

		private async void Button_Click(object sender, RoutedEventArgs e)
		{
			var picker = new Windows.Storage.Pickers.FileOpenPicker();
			picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
			picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
			picker.FileTypeFilter.Add(".jpg");
			picker.FileTypeFilter.Add(".jpeg");
			picker.FileTypeFilter.Add(".png");

			Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();


			using (Windows.Storage.Streams.IRandomAccessStream fileStream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read))
			{
				BitmapImage bitmapImage = new BitmapImage();
				await bitmapImage.SetSourceAsync(fileStream);
				OpenedImage.Source = bitmapImage;
			}

			NoPicButton.Visibility = Visibility.Collapsed;

			var schnitzelDetector = new SchnitzelDetector();

			try
			{
				ResultTextBox.Text = String.Empty;
				ResultTextBox.Visibility = Visibility.Collapsed;
				IsLoadingGrid.Visibility = Visibility.Visible;
				var result = await schnitzelDetector.IsSchnitzel(file.Path, file.Name);
				if(result)
				{
					ResultTextBox.Text = "It's a schnitzel!!";
				}
				else
				{
					ResultTextBox.Text = "Nope, it's not a schnitzel";
				}
			}
			catch(Exception exception)
			{

			}
			finally
			{
				ResultTextBox.Visibility = Visibility.Visible;
				IsLoadingGrid.Visibility = Visibility.Collapsed;
			}
			//if (file != null)
			//{
			//	// Application now has read/write access to the picked file
			//	this.textBlock.Text = "Picked photo: " + file.Name;
			//}
			//else
			//{
			//	this.textBlock.Text = "Operation cancelled.";
			//}
		}
	}
}
