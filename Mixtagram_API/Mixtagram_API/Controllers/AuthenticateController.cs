using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Mixtagram_API.Models;

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;

namespace Mixtagram_API.Controllers
{
    public class AuthenticateController : ApiController
    {
        Authenticate response = new Authenticate
        {
            Success = true
            ,ErrorCode = null
            ,ErrorDesc = null
            ,UserID = "29469225-2ED4-47FE-BCC1-3594A9FE152F"
            ,SessionID = "A7BC617A-734A-416E-AB5B-EE1FE04B2EEA"
        };

        public Authenticate Get()
        {
            /*
            var credential = MongoCredential.CreateMongoCRCredential("test", "user1", "password1");
            var settings = new MongoClientSettings
            {
                Credentials = new[] { credential }
            };
            var mongoClient = new MongoClient(settings);
            */
            var connectionString = "mongodb://mixtagram:mixtagram01!@172.16.252.1/mixtagram";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("mixtagram");
            var collection = database.GetCollection<User>("users");

            var query =
                from u in collection.AsQueryable<User>()
                where u.user == "test"
                select u;

            User user = query.First();
            response.ErrorDesc = user.user + ", " + user.pwd;

            return response;
        }

        /*
        // GET api/authenticate
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/authenticate/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/authenticate
        public void Post([FromBody]string value)
        {
        }

        // PUT api/authenticate/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/authenticate/5
        public void Delete(int id)
        {
        }
        */
    }
}
