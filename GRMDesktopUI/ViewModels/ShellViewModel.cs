using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace GRMDesktopUI.ViewModels
{
    public class ShellViewModel :Conductor<object>
    {
        private LoginViewModel _LoginVM;
        public ShellViewModel(LoginViewModel loginVM)
        {
            _LoginVM = loginVM;
            ActivateItemAsync(_LoginVM);
        }

        
    }
}
