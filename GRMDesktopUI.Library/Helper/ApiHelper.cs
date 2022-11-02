using GRMDesktopUI.Library.Helper;
using GRMDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GRMDesktopUI.Library.Helper
{
    public class ApiHelper : IApiHelper
    {
        
        private ILogInUser _logUser;

        private HttpClient _apiHelper;
        

        public HttpClient ApiClient
        {
            get
            {
                return _apiHelper;
            }
            
        }

       

        public ApiHelper(ILogInUser logInUser)
        {
            InitClient();
            this._logUser = logInUser;
           
        }

        private void InitClient()
        {
            _apiHelper = new HttpClient();
            _apiHelper.BaseAddress = new Uri(ConfigurationManager.AppSettings.Get("api"));
            _apiHelper.DefaultRequestHeaders.Accept.Clear();
            _apiHelper.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }
        public async Task<AuthenticatedUser> Authenticate(string username,string password)
        {
            var data = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string,string>("grant_type","password"),
                new KeyValuePair<string,string>("username",username),
                new KeyValuePair<string,string>("password",password),

            });
            using (HttpResponseMessage respones = await _apiHelper.PostAsync("/token",data))
            {
                if (respones.IsSuccessStatusCode)
                {
                    var result = await respones.Content.ReadAsAsync<AuthenticatedUser>();
                    return result;
                }
                else
                {
                    throw new Exception(respones.ReasonPhrase);
                }
            }
        }

        public async Task LoginInformation(string token)
        {
            _apiHelper.DefaultRequestHeaders.Clear();
            _apiHelper.DefaultRequestHeaders.Accept.Clear();
            _apiHelper.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _apiHelper.DefaultRequestHeaders.Add("Authorization", $"bearer {token}");

            using (HttpResponseMessage respones = await _apiHelper.GetAsync("/api/User"))
            {
                if (respones.IsSuccessStatusCode)
                {
                    var result = await respones.Content.ReadAsAsync<LogInUser>();
                    _logUser.AccessToken = token;
                    _logUser.FirstName = result.FirstName;
                    _logUser.LastName = result.LastName;
                    _logUser.EmailAddress = result.EmailAddress;
                    _logUser.CreatedData = result.CreatedData;
                }
                else
                {
                    throw new Exception(respones.ReasonPhrase);
                }
            }
        }
    }
}
