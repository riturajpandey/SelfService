using Acr.UserDialogs;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using SelfService.Managers.DeviceAPIManager;
using SelfService.Managers.SettingManager;
using SelfService.Providers.ApiProvider;

namespace SelfService
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public static string token = "";
        public static string DeviceType = "";
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
            Mvx.RegisterSingleton<IUserDialogs>(() => UserDialogs.Instance);
            Mvx.RegisterType<IDeviceAPIManager, DeviceAPIManager>();
            Mvx.RegisterType<ISettingsManager, SettingsManager>();
            Mvx.RegisterType<IApiProvider, ApiProvider>();
            if (token == "0")
            {
                //RegisterAppStart<ViewModels.RegistrationViewModel WelcomePageViewModel>();
                Mvx.RegisterSingleton<IMvxAppStart>(new MvxAppStart<ViewModels.RegistrationViewModel>());
            }
            else if (token == "1")
            {
                //RegisterAppStart<ViewModels.WelcomePageViewModel>();
                Mvx.RegisterSingleton<IMvxAppStart>(new MvxAppStart<ViewModels.WelcomePageViewModel>());
            }
        }
    }
}
