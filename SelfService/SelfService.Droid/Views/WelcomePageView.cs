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

namespace SelfService.Droid.Views
{
    [Activity(Theme = "@android:style/Theme.NoTitleBar", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    class WelcomePageView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.WelcomePage);
            Acr.UserDialogs.UserDialogs.Init(this);
        }
    }
}