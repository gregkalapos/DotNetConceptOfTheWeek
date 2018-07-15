using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using SchnitzelOrNotClient;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SchnitzelOrNot.Uwp
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
				SelectedImage.Source = bitmapImage;
			}

			var schnitzelDetector = 
				new SchnitzelDetector("AKIAJFHV4ILY7OS5LALQ", "cmxRYkx/cNY2iyW5fvi3Hy8o3+RK8nPJcbehfJ34");

			
			try
			{
				IsLoading.Visibility = Visibility.Visible;
				ResultTb.Text = "";
				var result = await schnitzelDetector.IsSchnitzel(file.Path, file.Name);

				if (result)
				{
					ResultTb.Text = "It's a schnitzel!!";
				}
				else
				{
					ResultTb.Text = "Nope, it's not a schnitzel";
				}
			}
			finally
			{
				IsLoading.Visibility = Visibility.Collapsed;
			}

		}
	}
}
