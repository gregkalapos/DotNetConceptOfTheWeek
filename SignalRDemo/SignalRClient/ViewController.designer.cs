// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace SignalRClient
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel AllMsgs { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField EnteredMsg { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton SendBtn { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (AllMsgs != null) {
                AllMsgs.Dispose ();
                AllMsgs = null;
            }

            if (EnteredMsg != null) {
                EnteredMsg.Dispose ();
                EnteredMsg = null;
            }

            if (SendBtn != null) {
                SendBtn.Dispose ();
                SendBtn = null;
            }
        }
    }
}