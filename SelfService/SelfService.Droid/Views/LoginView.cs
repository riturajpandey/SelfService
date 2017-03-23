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
    class LoginView : MvxActivity
    {

        // TODO: Declare class level varriable.
        LoginViewModel _loginViewModel;
        public static Context mContext;
        EditText username;
        EditText password;
        TextView signIn;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            _loginViewModel = (LoginViewModel)this.ViewModel;
            mContext = this;
            SetContentView(Resource.Layout.login);

            // TODO: Find Controlls.
            username = this.FindViewById<EditText>(Resource.Id.username);
            password = this.FindViewById<EditText>(Resource.Id.password);
            signIn = this.FindViewById<TextView>(Resource.Id.signIn);

            signIn.Click += (s, arg) =>
            {
                _loginViewModel.EmailAddress = username.Text;
                _loginViewModel.Password = password.Text;
                CallLoginCommand();
            };

        }


        public async void CallLoginCommand()
        {
            bool result = await _loginViewModel.SignInProcess();
            if (result == true)
            {
                //RegisterWithGCM();
                _loginViewModel.SignInCommand.Execute(this);
            }
        }

    }
}