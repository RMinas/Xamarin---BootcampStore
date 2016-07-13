// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace BootcampStore.iOS
{
	[Register ("LoginViewController")]
	partial class LoginViewController
	{
		[Outlet]
		UIKit.UIActivityIndicatorView Activityindicator { get; set; }

		[Outlet]
		UIKit.UIButton LoginBtn { get; set; }

		[Outlet]
		UIKit.UITextField Password { get; set; }

		[Outlet]
		UIKit.UITextField Username { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (Username != null) {
				Username.Dispose ();
				Username = null;
			}

			if (Password != null) {
				Password.Dispose ();
				Password = null;
			}

			if (LoginBtn != null) {
				LoginBtn.Dispose ();
				LoginBtn = null;
			}

			if (Activityindicator != null) {
				Activityindicator.Dispose ();
				Activityindicator = null;
			}
		}
	}
}
