using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mixtagram_API.Models
{
    public class AuthenticateResponse
    {
        public bool Success { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorDesc { get; set; }
        public string UserID { get; set; }
        public string SessionID { get; set; }
    }
}