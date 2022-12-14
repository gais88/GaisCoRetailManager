using Caliburn.Micro;
using GRMDesktopUI.Events;
using GRMDesktopUI.Library.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRMDesktopUI.ViewModels
{
    public class LoginViewModel : Screen
    {
        private string _userName;
        private string _password;
        private IApiHelper _apiHelper;
        private readonly IEventAggregator _event;
        private bool _isErroMessage;
        private string _erroMessage;

        public string ErroMessage
        {
            get { return _erroMessage; }
            set {
                _erroMessage = value;
                NotifyOfPropertyChange(() => ErroMessage);
                NotifyOfPropertyChange(() => IsErrorVisible);
            }
        }


        public bool IsErrorVisible
        {
            get {
                bool output = false;
                if (ErroMessage?.Length> 0) { output = true; }
                    
                return output;
            }
           
        }

        public LoginViewModel(IApiHelper apiHelper , IEventAggregator eventAggr)
        {
            _apiHelper = apiHelper;
            _event = eventAggr;
        }
        public string UserName
        {
            get { return _userName; }
            set {
                _userName = value;
                NotifyOfPropertyChange(() => UserName);
                NotifyOfPropertyChange(() => CanLogin);
            }
        }
        public string Password
        {
            get { return _password; }
            set {
                _password = value;
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanLogin);
            }
        }
        public bool CanLogin
        {
            get
            {
                if (UserName?.Length > 0 && Password?.Length > 0)
                {
                    return true;
                }
                else
                    return false;
            }

        }
        public async Task Login()
        {
            try
            {
                ErroMessage = "";
                var result = await _apiHelper.Authenticate(UserName, Password);
                // captuer login info user
                await _apiHelper.LoginInformation(result.access_token);

                await _event.PublishOnUIThreadAsync(new LogInEvent());
            }
            catch(Exception e)
            {
                ErroMessage = e.Message;
            }
        }



    }
}
