using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MongoDB.Bson;

namespace Mixtagram_API.Models
{
    public class User
    {
        public ObjectId id { get; set; }
        public string user { get; set; }
        public string pwd { get; set; }
        public string[] roles { get; set; }
    }
}