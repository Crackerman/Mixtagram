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
        public CreateUserResponse Get(
            string firstName, string lastName, string email, string password,
            string CCNumber = null, string CCExpiration = null, string CCZip = null, string CCSecurityCode = null)
        {
            return CreateUser(
                firstName, lastName, email, password,
                CCNumber, CCExpiration, CCZip, CCSecurityCode);
        }

        public CreateUserResponse Post(CreateUserPost post)
        {
            return CreateUser(
                post.FirstName, post.LastName, post.Email, post.Password,
                post.CCNumber, post.CCExpiration, post.CCZip, post.CCSecurityCode);
        }

        private CreateUserResponse CreateUser(
            string firstName, string lastName, string email, string password,
            string CCNumber = null, string CCExpiration = null, string CCZip = null, string CCSecurityCode = null)
        {
            CreateUserResponse response = new CreateUserResponse { Success = false };
            var db = MongoDBHelper.GetMixtagramDatabase();
            var collection = db.GetCollection<User>("users");

            //Validate required fields
            if(string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                response.Success = false;
                response.ErrorCode = "1";
                response.ErrorDesc = "Required field is missing.";
                return response;
            }

            //Validate field formats

            //Check if email address already exists
            var query =
                from u in collection.AsQueryable<User>()
                where u.Email == email
                select u;

            List<User> users = query.ToList();
            if (users.Count() > 0)
            {
                response.Success = false;
                response.ErrorCode = "3";
                response.ErrorDesc = "Email address already exists.";
                return response;
            }

            //Validate password

            //Validate credit card number

            //Create account
            User user = new User();
            user.FirstName = firstName;
            user.LastName = lastName;
            user.Email = email;
            user.Password = password;
            user.SessionID = Guid.NewGuid().ToString();
            collection.Save(user);

            //Create account with merchant account provider

            response.Success = true;
            response.UserID = user.id.ToString();
            response.SessionID = user.SessionID;

            return response;
        }
    }
}
