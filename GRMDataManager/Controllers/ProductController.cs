using GRMDataManager.Library.DataAccess;
using GRMDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GRMDataManager.Controllers
{
    //[Authorize]
    public class ProductController : ApiController
    {
        public ProductController()
        {

        }
        public List<ProductModel> GetProductList()
        {
            var poductData = new ProductData();
            var data =poductData.GetProductList();
            return data;
            
        }
    }
}
