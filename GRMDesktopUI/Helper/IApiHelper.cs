using System.Threading.Tasks;
using GRMDesktopUI.Models;

namespace GRMDesktopUI.Helper
{
    public interface IApiHelper
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);
    }
}