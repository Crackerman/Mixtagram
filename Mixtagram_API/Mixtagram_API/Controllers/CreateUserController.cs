using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Mixtagram_API.Models;
using Mixtagram_API.HelperClasses;

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;

namespace Mixtagram_API.Controllers
{
    public class CreateUserController : ApiController
    {
        public CreateUserResponse Get()
        {
            return new CreateUserResponse();
        }

        public CreateUserResponse Post()
        {
            return new CreateUserResponse();
        }
    }
}
