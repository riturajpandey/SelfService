using System;
using MvvmCross.iOS.Views;
using UIKit;

namespace SelfService.iOS
{
	public partial class WelcomePageView : MvxViewController
	{
		public WelcomePageView() : base("WelcomePageView", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			this.NavigationController.SetNavigationBarHidden(true,false);
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

