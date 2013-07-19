using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mixtagram_API.Models
{
    public class AuthenticatePost
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}