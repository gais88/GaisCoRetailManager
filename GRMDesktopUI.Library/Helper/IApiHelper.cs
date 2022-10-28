using System.Threading.Tasks;
using GRMDesktopUI.Library.Models;


namespace GRMDesktopUI.Library.Helper
{
    public interface IApiHelper
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);
        Task LoginInformation(string token);
    }
}