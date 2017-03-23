using Acr.UserDialogs;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
//using Windows.UI.Popups;

namespace SelfService.ViewModels
{
    public class RegistrationViewModel : BaseViewModel
    {


        public RegistrationViewModel()
        { }

        // TODO: Add raise properties for this viewmodel.
        private string _registrationNumber = "";
        public string registrationNumber
        {
            get { return _registrationNumber; }
            set { _registrationNumber = value; RaisePropertyChanged(() => registrationNumber); }
        }

        public ICommand RegisterCommand
        {
            get
            {
                return new MvxCommand(RegisterEvent);
            }
        }

        private async void RegisterEvent()
        {
            bool result = await RegisterProcess();
            if (result)
            {
                ShowViewModel<WelcomePageViewModel>();
            }
        }

        public async Task<bool> RegisterProcess()
        {
            bool result = true;
            //TLPWEBServices.GetUser_JSON("JDddd");
            if (registrationNumber.Length == 0)
            {
                if (App.DeviceType == "droid" || App.DeviceType == "IOS")
                {
                    DialogService.Alert("Please enter your Registration Number.", null, "OK");
                }
                else
                {
                    //UserDialogs.Instance.Alert("Please enter your Registration Number.");
                }
                result = false;
            }
            App.token = registrationNumber;
            if (App.DeviceType == "droid" || App.DeviceType == "IOS")
            {
                DialogService.ShowLoading("Loading...", Acr.UserDialogs.MaskType.Black);
            }
            //MessageDialog msgbox_ = new MessageDialog("Loading...");
            //msgbox_.ShowAsync();

            try
            {
                //TODO: Call async method.
                if (App.DeviceType == "droid" || App.DeviceType == "IOS")
                {
                    var resultAPI = await deviceAPItManager.PostRegistration(registrationNumber);
                    // TODO : Perform the result accordly API Result.

                    DialogService.HideLoading();
                }
            }
            catch (Exception ex)
            {
                if (App.DeviceType == "droid" || App.DeviceType == "IOS")
                {
                    DialogService.HideLoading();
                    DialogService.Alert("Something went wrong, please try again", null, "OK");
                    result = false;
                }
            }
            return result;
        }
    }
}
