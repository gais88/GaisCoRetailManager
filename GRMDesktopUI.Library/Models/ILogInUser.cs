using System;

namespace GRMDesktopUI.Library.Models
{
    public interface ILogInUser
    {
        string AccessToken { get; set; }
        DateTime CreatedData { get; set; }
        string EmailAddress { get; set; }
        string FirstName { get; set; }
        string Id { get; set; }
        string LastName { get; set; }
    }
}