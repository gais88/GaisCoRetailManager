using GRMDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GRMDesktopUI.Library.Helper
{
    public class ProductEndPoint : IProductEndPoint
    {
        IApiHelper _apiHelper;
        public ProductEndPoint(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }
        public async Task<List<ProductList>> GetAll()
        {

            using (HttpResponseMessage respones = await _apiHelper.ApiClient.GetAsync("/api/Product"))
            {
                if (respones.IsSuccessStatusCode)
                {
                    var result = await respones.Content.ReadAsAsync<List<ProductList>>();
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
