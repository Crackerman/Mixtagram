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
    public class AuthenticateController : ApiController
    {
        public AuthenticateResponse Get(string email = null, string password = null)
        {
            return Authenticate(email, password);
        }

        public AuthenticateResponse Post(AuthenticatePost post)
        {
            return Authenticate(post.Email, post.Password);
        }

        private AuthenticateResponse Authenticate(string email, string password)
        {
            AuthenticateResponse response = new AuthenticateResponse { Success = false };

            //Check for required parameters/fields
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                response.Success = false;
                response.ErrorCode = "1";
                response.ErrorDesc = "Required field is missing.";

                return response;
            }

            //Authenticate
            var db = MongoDBHelper.GetMixtagramDatabase();
            var collection = db.GetCollection<User>("users");

            var query =
                from u in collection.AsQueryable<User>()
                where u.Email == email && u.Password == password
                select u;

            List<User> users = query.ToList();
            if (users.Count() > 0)
            {
                User user = users[0];
                response.Success = true;

                //Create session identifier
                user.SessionID = Guid.NewGuid().ToString();
                collection.Save(user);
                response.SessionID = user.SessionID;

                response.UserID = user.id.ToString();
            }
            else
            {
                response.Success = false;
                response.ErrorCode = "2";
                response.ErrorDesc = "Invalid email address/password combination.";
            }

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
