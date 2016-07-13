using System;
using BootcampStore.Core.Models;
using Foundation;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace BootcampStore.iOS
{
	public class StoreListTableSource : MvxStandardTableViewSource
	{
		public StoreListTableSource(UITableView TableView) : base(TableView)
		{
		}

		public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
		{
			return 200f;
		}

		protected override UITableViewCell GetOrCreateCellFor(UITableView tableView,
															  Foundation.NSIndexPath indexPath,
															  object item)
		{
			Store storeObj = (Store)item;

			//var cell = tableView.DequeueReusableCell(CellIdentifier);
			//if (cell == null)
			//{
			//	cell = new UITableViewCell(UITableViewCellStyle.Subtitle, CellIdentifier);
			//}

			//cell.TextLabel.Text = storeObj.Name;
			//cell.DetailTextLabel.Text = storeObj.Address;

			//cell.ImageView.Image = null;
			//if (storeObj.PhotoUrl != null)
			//{
			//	using (var url = new NSUrl(storeObj.PhotoUrl))
			//	using (var data = NSData.FromUrl(url))
			//		if (data != null)
			//			cell.ImageView.Image = UIImage.LoadFromData(data);
			//}

			var cell = tableView.DequeueReusableCell(StoreItemTableViewCell.Key) as StoreItemTableViewCell;
			if (cell == null)
			{
				cell = StoreItemTableViewCell.Create();
			}

			cell.NameProp.Text = storeObj.Name;
			cell.PhoneProp.Text = storeObj.Phone;
			cell.AddressProp.Text = storeObj.Address;

			if (storeObj.Name != null && storeObj.Name.Contains("Store"))
			{
				cell.AddressProp.Text = storeObj.Address;
				cell.AddressProp.Hidden = false;
			}
			else
			{
				cell.AddressProp.Hidden = true;
			}

			return cell;
		}
	}
}

