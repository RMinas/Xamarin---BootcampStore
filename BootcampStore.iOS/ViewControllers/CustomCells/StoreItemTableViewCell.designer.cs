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
	[Register ("StoreItemTableViewCell")]
	partial class StoreItemTableViewCell
	{
		[Outlet]
		UIKit.UILabel Address { get; set; }

		[Outlet]
		UIKit.UILabel Name { get; set; }

		[Outlet]
		UIKit.UILabel Phone { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (Address != null) {
				Address.Dispose ();
				Address = null;
			}

			if (Name != null) {
				Name.Dispose ();
				Name = null;
			}

			if (Phone != null) {
				Phone.Dispose ();
				Phone = null;
			}
		}
	}
}
