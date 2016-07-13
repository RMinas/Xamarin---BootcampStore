using System;
using BootcampStore.Core;
using BootcampStore.Core.Models;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using UIKit;

namespace BootcampStore.iOS
{
	public partial class StoreMapViewController : MvxViewController<StoreMapViewModel>
	{
		public StoreMapViewController() : base("StoreMapViewController", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			var set = this.CreateBindingSet<StoreMapViewController, StoreMapViewModel>();
			set.Apply();

			ViewModel.Initialization.PropertyChanged += (sender, e) =>
			{
				foreach (Store s in ViewModel.Stores)
				{
					storemap.AddAnnotation(new MapKit.MKPointAnnotation()
					{
						Title = s.Name,
						Coordinate = new CoreLocation.CLLocationCoordinate2D(Double.Parse(s.Lat), Double.Parse(s.Lng))
					});
				}
			};

		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


