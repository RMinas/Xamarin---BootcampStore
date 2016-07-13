using System;
using BootcampStore.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;
using UIKit;

namespace BootcampStore.iOS
{
	public partial class StoreListViewController : MvxViewController<StoreListViewModel>
	{
		public StoreListViewController() : base("StoreListViewController", null)
		{
		}

		private MvxTableViewSource _tableViewSource;

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			_tableViewSource = new StoreListTableSource(StoresTableView);
			StoresTableView.Source = _tableViewSource;

			var set = this.CreateBindingSet<StoreListViewController, StoreListViewModel>();
			set.Bind(CreateStoreBtn).To(ViewModel => ViewModel.CreateCommand);
			set.Bind(ActivityIndicator).For(prop => prop.Hidden).
			   To(ViewModel => ViewModel.IsBusy).WithConversion(new VisibilityConverter());

			set.Bind(_tableViewSource).For(prop => prop.ItemsSource).To(ViewModel => ViewModel.Stores);
			set.Apply();

			UIRefreshControl refresh = new UIRefreshControl();
			refresh.BackgroundColor = UIColor.LightGray;
			refresh.TintColor = UIColor.White;
			refresh.ValueChanged += (sender, e) =>
			{
				ViewModel.RefreshListCommand.Execute();
				refresh.EndRefreshing();
			};
			StoresTableView.AddSubview(refresh);
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


