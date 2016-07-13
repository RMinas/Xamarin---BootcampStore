using System;
using BootcampStore.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using UIKit;

namespace BootcampStore.iOS
{
	public partial class MenuViewController : MvxViewController<MenuViewModel>
	{
		public MenuViewController() : base("MenuViewController", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			var set = this.CreateBindingSet<MenuViewController, MenuViewModel>();

			set.Bind(LogoutBtn).To(ViewModel => ViewModel.LogoutCommand);
			set.Bind(StoresBtn).To(ViewModel => ViewModel.ShowStoresCommand);
			set.Bind(PromotionsBtn).To(ViewModel => ViewModel.ShowPromotionsCommand);
			set.Bind(MapBtn).To(ViewModel => ViewModel.ShowStoresMapCommand);

			set.Apply();
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			NavigationController.NavigationBar.Hidden = true;
		}
	}
}


