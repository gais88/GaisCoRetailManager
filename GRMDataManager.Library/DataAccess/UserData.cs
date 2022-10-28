using GRMDataManager.Library.Internal.DataAccess;
using GRMDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRMDataManager.Library.DataAccess
{
    public class UserData
    {
        public List<UserModel> GetUserById(string Id)
        {
            var sqlData = new SqlDataAccess();
            var parameter = new { Id = Id};
            var output = sqlData.LoadData<UserModel,dynamic>("spUserLookUp", parameter, "GRMData");
            return output;
        }
    }
}
