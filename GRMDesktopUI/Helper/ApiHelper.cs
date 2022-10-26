using GRMDesktopUI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GRMDesktopUI.Helper
{
    public class ApiHelper : IApiHelper
    {
        private HttpClient ApiClient;
        public ApiHelper()
        {
            InitClient();
        }

        private void InitClient()
        {
            ApiClient = new HttpClient();
            ApiClient.BaseAddress = new Uri(ConfigurationManager.AppSettings.Get("api"));
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }
        public async Task<AuthenticatedUser> Authenticate(string username,string password)
        {
            var data = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string,string>("grant_type","password"),
                new KeyValuePair<string,string>("username",username),
                new KeyValuePair<string,string>("password",password),

            });
            using (HttpResponseMessage respones = await ApiClient.PostAsync("/token",data))
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
    }
}
