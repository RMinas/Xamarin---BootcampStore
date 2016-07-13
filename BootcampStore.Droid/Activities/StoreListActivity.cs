using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Views;
using BootcampStore.Core.ViewModels;
using Android.Support.V4.Widget;

namespace BootcampStore.Droid.Activities
{
    [Activity(Label = "StoreListActivity",
    ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait,
    WindowSoftInputMode = SoftInput.StateHidden)]
    public class StoreListActivity : MvxActivity<StoreListViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.store_list);

            var srlStores = FindViewById<SwipeRefreshLayout>(Resource.Id.srlStores);
            srlStores.Refresh += (IntentSender, args) => ViewModel.RefreshListCommand.Execute();
        }

        protected override void OnResume()
        {
            base.OnResume();
            ViewModel.RefreshListCommand.Execute();
        }
    }
}