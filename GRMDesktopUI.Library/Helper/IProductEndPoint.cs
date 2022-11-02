using System.Collections.Generic;
using System.Threading.Tasks;
using GRMDesktopUI.Library.Models;

namespace GRMDesktopUI.Library.Helper
{
    public interface IProductEndPoint
    {
        Task<List<ProductList>> GetAll();
    }
}