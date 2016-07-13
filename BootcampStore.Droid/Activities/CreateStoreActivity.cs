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
using BootcampStore.Core.ViewModels;
using MvvmCross.Droid.Views;

namespace BootcampStore.Droid.Activities
{
    [Activity(Label = "CreateStoreActivity",
        NoHistory = true,
        ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait,
        WindowSoftInputMode = SoftInput.StateHidden)]
    public class CreateStoreActivity : MvxActivity<CreateStoreViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.create_store);
        }
    }
}