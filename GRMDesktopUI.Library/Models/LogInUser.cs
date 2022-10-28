using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRMDesktopUI.Library.Models
{
    public class LogInUser : ILogInUser
    {
        public string AccessToken { get; set; }  
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime CreatedData { get; set; }
    }
}
