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
	[Register ("MenuViewController")]
	partial class MenuViewController
	{
		[Outlet]
		UIKit.UIButton LogoutBtn { get; set; }

		[Outlet]
		UIKit.UIButton MapBtn { get; set; }

		[Outlet]
		UIKit.UIButton PromotionsBtn { get; set; }

		[Outlet]
		UIKit.UIButton StoresBtn { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (StoresBtn != null) {
				StoresBtn.Dispose ();
				StoresBtn = null;
			}

			if (PromotionsBtn != null) {
				PromotionsBtn.Dispose ();
				PromotionsBtn = null;
			}

			if (MapBtn != null) {
				MapBtn.Dispose ();
				MapBtn = null;
			}

			if (LogoutBtn != null) {
				LogoutBtn.Dispose ();
				LogoutBtn = null;
			}
		}
	}
}
