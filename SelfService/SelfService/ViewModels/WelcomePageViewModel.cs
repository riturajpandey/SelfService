using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfService.ViewModels
{
    public class WelcomePageViewModel : BaseViewModel
    {
        public WelcomePageViewModel()
        {
            showLoginPage();
        }

        async public void showLoginPage()
        {
            await Task.Delay(5000);
            ShowViewModel<LoginViewModel>();
        }
    }
}
