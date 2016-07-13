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
	[Register ("StoreListViewController")]
	partial class StoreListViewController
	{
		[Outlet]
		UIKit.UIActivityIndicatorView ActivityIndicator { get; set; }

		[Outlet]
		UIKit.UIButton CreateStoreBtn { get; set; }

		[Outlet]
		UIKit.UITableView StoresTableView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (StoresTableView != null) {
				StoresTableView.Dispose ();
				StoresTableView = null;
			}

			if (ActivityIndicator != null) {
				ActivityIndicator.Dispose ();
				ActivityIndicator = null;
			}

			if (CreateStoreBtn != null) {
				CreateStoreBtn.Dispose ();
				CreateStoreBtn = null;
			}
		}
	}
}
