using Acr.UserDialogs;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SelfService.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel()
        { }

        // TODO: Add raise properties for this viewmodel.
        private string _emailAddress = "";
        public string EmailAddress
        {
            get { return _emailAddress; }
            set { _emailAddress = value; RaisePropertyChanged(() => EmailAddress); }
        }

        private string _password = "";
        public string Password
        {
            get { return _password; }
            set { _password = value; RaisePropertyChanged(() => Password); }
        }


        // TODO: Get Fire SignIn Command.
        public ICommand SignInCommand
        {
            get
            {
                return new MvxCommand(SignInEvent);
            }
        }

        private async void SignInEvent()
        {
            bool result = await SignInProcess();
            if (result)
            {
                //ShowViewModel<MainViewModel>();
            }
        }

        public async Task<bool> SignInProcess()
        {
            bool result = false;
            //TLPWEBServices.GetUser_JSON("JDddd");
            if (EmailAddress.Length == 0)
            {
                if (App.DeviceType == "droid" || App.DeviceType == "IOS")
                {
                    DialogService.Alert("Please enter your email address.", null, "OK");
                }
                return result;
            }
            else if (Password.Length == 0)
            {
                if (App.DeviceType == "droid" || App.DeviceType == "IOS")
                {
                    DialogService.Alert("Please enter your password.", null, "OK");
                }
                return result;
            }
            if (App.DeviceType == "droid" || App.DeviceType == "IOS")
            {
                DialogService.ShowLoading("Loading...", Acr.UserDialogs.MaskType.Black);
            }
            try
            {
                //TODO: Call async method.
                if (App.DeviceType == "droid" || App.DeviceType == "IOS")
                {
                    DialogService.HideLoading();
                }
            }
            catch (Exception ex)
            {
                if (App.DeviceType == "droid" || App.DeviceType == "IOS")
                {
                    DialogService.HideLoading();
                    DialogService.Alert("Something went wrong, please try again", null, "OK");
                }
                result = false;
            }
            return result;
        }

    }
}