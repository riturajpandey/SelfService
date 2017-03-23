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
using SelfService.ViewModels;

namespace SelfService.Droid.Views
{
    [Activity(Theme = "@android:style/Theme.NoTitleBar", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    class RegistrationView : MvxActivity
    {
        RegistrationViewModel _registrationViewModel;

        public static Context mContext;
        EditText RegistrationNumber;
        Button btnregister;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            _registrationViewModel = (RegistrationViewModel)this.ViewModel;
            mContext = this;
            SetContentView(Resource.Layout.Registration);
            Acr.UserDialogs.UserDialogs.Init(this);
            // TODO: Find Controlls.
            RegistrationNumber = this.FindViewById<EditText>(Resource.Id.RegistrationNumber);
            btnregister = this.FindViewById<Button>(Resource.Id.btnregister);
            btnregister.Click += (s, arg) =>
            {
                _registrationViewModel.registrationNumber = RegistrationNumber.Text;
                CallLoginCommand();
            };
        }


        public async void CallLoginCommand()
        {
            bool result = await _registrationViewModel.RegisterProcess();
            if (result == true)
            {
                App.token = _registrationViewModel.registrationNumber;
                _registrationViewModel.RegisterCommand.Execute(this);
            }
        }
    }
}