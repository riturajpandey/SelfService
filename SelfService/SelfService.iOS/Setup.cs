using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Platform.Platform;
using UIKit;

namespace SelfService.iOS
{
    public class Setup : MvxIosSetup
	{
		public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window)
			: base(applicationDelegate, window)
		{
		}

		protected override IMvxApplication CreateApp()
		{
			App.token = "0";
			App.DeviceType = "IOS";
			return new App();
		}

		protected override IMvxTrace CreateDebugTrace()
		{
			return new DebugTrace();
		}
	}
}
