using System;
using SchnitzelOrNotClient;
using UIKit;

namespace SchnitzelOrNot.iOS
{
	public partial class ViewController : UIViewController
	{
		
		partial void UIButton198_TouchUpInside(UIButton sender)
		{
			// Create and define UIImagePickerController
			var imagePicker = new UIImagePickerController
			{
				SourceType = UIImagePickerControllerSourceType.PhotoLibrary,
				MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.PhotoLibrary)
			};

			// Set event handlers
			imagePicker.FinishedPickingMedia += async (s, e) =>
			{
				imagePicker.DismissModalViewController(true);
				SelectImgLabel.Hidden = true;

				var sdetector = new SchnitzelDetector();
				var imgUrl = e.ImageUrl;

				MainImgView.ContentMode = UIViewContentMode.ScaleAspectFit;

				MainImgView.Image = e.OriginalImage;

				try
				{
					LoadingLabel.Hidden = false;
					LoadingIndicator.Hidden = false;
					IsSchnitzelLabel.Text = String.Empty;
					RedXImg.Hidden = true;
					GreenCImg.Hidden = true;

					var res = await sdetector.IsSchnitzel(imgUrl.Path, "aaa.jpg");

					if (res)
					{
						IsSchnitzelLabel.Text = "Yes, it's a Schnitzel!";
						GreenCImg.Hidden = false;
					}
					else
					{
						IsSchnitzelLabel.Text = "Nope, it's not a Schnitzel";
						RedXImg.Hidden = false;
					}
				}
				finally
				{
					LoadingLabel.Hidden = true;
					LoadingIndicator.Hidden = true;
				}
			};

			//imagePicker.Canceled += OnImagePickerCancelled;

			// Present UIImagePickerController;
			UIWindow window = UIApplication.SharedApplication.KeyWindow;
			var viewController = window.RootViewController;
			viewController.PresentModalViewController(imagePicker, true);


		}

		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}
