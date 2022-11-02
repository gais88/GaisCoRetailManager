using GRMDataManager.Library.Internal.DataAccess;
using GRMDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRMDataManager.Library.DataAccess
{
    public class ProductData
    {
        public List<ProductModel> GetProductList()
        {
            SqlDataAccess sqlData = new SqlDataAccess();
            var result = sqlData.LoadData<ProductModel, dynamic>("spProducts_GetAll", new { }, "GRMData");
            return result;
        }
    }
}
