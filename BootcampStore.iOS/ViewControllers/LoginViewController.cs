using System;
using BootcampStore.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using UIKit;

namespace BootcampStore.iOS
{
	public partial class LoginViewController : MvxViewController<LoginViewModel>
	{
		public LoginViewController() : base("LoginViewController", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			var set = this.CreateBindingSet<LoginViewController, LoginViewModel>();

			set.Bind(Username).To(ViewModel => ViewModel.Username);
			set.Bind(Password).To(ViewModel => ViewModel.Password);
			set.Bind(LoginBtn).To(ViewModel => ViewModel.LoginCommand);
			set.Bind(Activityindicator).For(prop => prop.Hidden).
			   To(ViewModel => ViewModel.IsBusy).
			   WithConversion(new VisibilityConverter());

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


