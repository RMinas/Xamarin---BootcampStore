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

namespace BootcampStore.Droid.Activities
{
    [Activity(Label = "MenuActivity",
        ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait,
        WindowSoftInputMode = SoftInput.StateHidden)]
    public class MenuActivity : MvxActivity<MenuViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.menu);
        }
    }
}