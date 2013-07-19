using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mixtagram_API.Models
{
    public class CreateUserPost
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email  { get; set; }
        public string Password { get; set; }
        public string CCNumber { get; set; }
        public string CCExpiration { get; set; }
        public string CCZip { get; set; }
        public string CCSecurityCode { get; set; }
    }
}