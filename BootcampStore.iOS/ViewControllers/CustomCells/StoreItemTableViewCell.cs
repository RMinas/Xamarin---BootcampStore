using System;

using Foundation;
using UIKit;

namespace BootcampStore.iOS
{
	public partial class StoreItemTableViewCell : UITableViewCell
	{
		public static readonly NSString Key = new NSString("StoreItemTableViewCell");
		public static readonly UINib Nib;

		public UILabel NameProp
		{
			get
			{
				return Name;
			}
			set
			{
				Name = value;
			}
		}

		public UILabel AddressProp
		{
			get
			{
				return Address;
			}
			set
			{
				Address = value;
			}
		}

		public UILabel PhoneProp
		{
			get
			{
				return Phone;
			}
			set
			{
				Phone = value;
			}
		}


		static StoreItemTableViewCell()
		{
			Nib = UINib.FromName("StoreItemTableViewCell", NSBundle.MainBundle);
		}

		protected StoreItemTableViewCell(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public static StoreItemTableViewCell Create()
		{
			return (StoreItemTableViewCell)Nib.Instantiate(null, null)[0];
		}
	}
}
