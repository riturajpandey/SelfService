using System;
using SelfService.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using UIKit;

namespace SelfService.iOS
{
	public partial class LoginView : MvxViewController
	{
		LoginViewModel vm;
		public LoginView() : base("LoginView", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			this.NavigationController.NavigationBar.Translucent = false;
			vm = this.ViewModel as LoginViewModel;
			this.NavigationController.SetNavigationBarHidden(false, false);
			this.Title = "Login";
			var set = this.CreateBindingSet<LoginView, LoginViewModel>();
			set.Bind(txtUserName).To(vm => vm.EmailAddress);
			set.Bind(txtPassword).To(vm => vm.Password);
			set.Bind(btnSign).To(vm => vm.SignInCommand);
			set.Apply();
			this.NavigationItem.SetHidesBackButton(true, false);
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

