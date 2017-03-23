// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace SelfService.iOS
{
	[Register ("LoginView")]
	partial class LoginView
	{
		[Outlet]
		UIKit.UIButton btnSign { get; set; }

		[Outlet]
		UIKit.UITextField txtPassword { get; set; }

		[Outlet]
		UIKit.UITextField txtUserName { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnSign != null) {
				btnSign.Dispose ();
				btnSign = null;
			}

			if (txtUserName != null) {
				txtUserName.Dispose ();
				txtUserName = null;
			}

			if (txtPassword != null) {
				txtPassword.Dispose ();
				txtPassword = null;
			}
		}
	}
}
