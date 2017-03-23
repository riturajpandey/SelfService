using SelfService.Managers.DeviceAPIManager;
using SelfService.Managers.SettingManager;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfService.ViewModels
{
    public class BaseViewModel : MvxViewModel
    {
        protected readonly IDeviceAPIManager deviceAPItManager;
        protected readonly ISettingsManager settingsManager;
        private readonly Dictionary<string, object> PropertyValues = new Dictionary<string, object>();

        public BaseViewModel()
        {
            deviceAPItManager = Mvx.Resolve<IDeviceAPIManager>();
            ////deviceAPItManager = SimpleIoc.Default.GetInstance<IDeviceAPIManager>();
            settingsManager = Mvx.Resolve<ISettingsManager>();
        }

        /// <summary>
        /// TODO: Register the dialog popups
        /// </summary>
        /// <value>The dialog service.</value>
        public Acr.UserDialogs.IUserDialogs DialogService
        {
            get
            {
                //var str = Mvx.Resolve<Acr.UserDialogs.IUserDialogs>();
                return Mvx.Resolve<Acr.UserDialogs.IUserDialogs>();
            }
        }
    }
}