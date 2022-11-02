using System.Net.Http;
using System.Threading.Tasks;
using GRMDesktopUI.Library.Models;


namespace GRMDesktopUI.Library.Helper
{
    public interface IApiHelper
    {
        HttpClient ApiClient { get; }
        Task<AuthenticatedUser> Authenticate(string username, string password);
        Task LoginInformation(string token);
    }
}