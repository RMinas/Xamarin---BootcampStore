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
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Views;
using BootcampStore.Core.ViewModels;

namespace BootcampStore.Droid.MvxCustom
{
    public class BootcampPresenter : MvxAndroidViewPresenter
    {
        protected override Intent CreateIntentForRequest(MvxViewModelRequest request)
        {
            var intent = base.CreateIntentForRequest(request);

            if(request.ViewModelType == typeof(LoginViewModel))
            {
                intent.SetFlags(ActivityFlags.NewTask | ActivityFlags.ClearTask);
            }

            return intent;
        }
    }
}