﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRMDesktopUI.Library.Models
{
    public class AuthenticatedUser
    {
        public string access_token { get; set; }
        public string UserName { get; set; }
    }
}
