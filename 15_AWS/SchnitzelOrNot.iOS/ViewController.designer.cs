// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace SchnitzelOrNot.iOS
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView GreenCImg { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel IsSchnitzelLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIActivityIndicatorView LoadingIndicator { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LoadingLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView MainImgView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView RedXImg { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel SelectImgLabel { get; set; }

        [Action ("UIButton198_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void UIButton198_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (GreenCImg != null) {
                GreenCImg.Dispose ();
                GreenCImg = null;
            }

            if (IsSchnitzelLabel != null) {
                IsSchnitzelLabel.Dispose ();
                IsSchnitzelLabel = null;
            }

            if (LoadingIndicator != null) {
                LoadingIndicator.Dispose ();
                LoadingIndicator = null;
            }

            if (LoadingLabel != null) {
                LoadingLabel.Dispose ();
                LoadingLabel = null;
            }

            if (MainImgView != null) {
                MainImgView.Dispose ();
                MainImgView = null;
            }

            if (RedXImg != null) {
                RedXImg.Dispose ();
                RedXImg = null;
            }

            if (SelectImgLabel != null) {
                SelectImgLabel.Dispose ();
                SelectImgLabel = null;
            }
        }
    }
}