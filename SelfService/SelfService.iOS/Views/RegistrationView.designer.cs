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
	[Register ("RegistrationView")]
	partial class RegistrationView
	{
		[Outlet]
		UIKit.UIButton btnReg { get; set; }

		[Outlet]
		UIKit.UITextField txtName { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnReg != null) {
				btnReg.Dispose ();
				btnReg = null;
			}

			if (txtName != null) {
				txtName.Dispose ();
				txtName = null;
			}
		}
	}
}
