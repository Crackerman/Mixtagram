using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mixtagram_API.Models
{
    public class GetUserResponse
    {
        public bool Success { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorDesc { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool HasCreditCard { get; set; }
    }
}