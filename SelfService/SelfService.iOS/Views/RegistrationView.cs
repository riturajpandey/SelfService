using System;
using SelfService.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using UIKit;

namespace SelfService.iOS
{
	public partial class RegistrationView : MvxViewController
	{
		RegistrationViewModel vm;
		public RegistrationView() : base("RegistrationView", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			this.NavigationController.NavigationBar.Translucent = false;
			this.Title = "Registration";
			vm = this.ViewModel as RegistrationViewModel;
			var set = this.CreateBindingSet<RegistrationView, RegistrationViewModel>();
			set.Bind(txtName).To(vm => vm.registrationNumber);
			set.Bind(btnReg).To(vm => vm.RegisterCommand);
			set.Apply();

			txtName.ShouldReturn += (UITextField textField) => {
				txtName.ResignFirstResponder();
				return true;
			};
			// Perform any additional setup after loading the view, typically from a nib.
		}



		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

