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
    public class GetUserController : ApiController
    {
        public GetUserResponse Get(string userID, string sessionID)
        {
            return GetUser(userID, sessionID);
        }

        public GetUserResponse Post(GetUserPost post)
        {
            return GetUser(post.UserID, post.SessionID);
        }

        private GetUserResponse GetUser(string userID, string sessionID)
        {
            GetUserResponse response = new GetUserResponse { Success = false };
            var db = MongoDBHelper.GetMixtagramDatabase();
            var collection = db.GetCollection<User>("users");
            ObjectId parsedUserID;

            //Validate required fields
            if (string.IsNullOrEmpty(userID) || string.IsNullOrEmpty(sessionID))
            {
                response.Success = false;
                response.ErrorCode = "1";
                response.ErrorDesc = "Required field is missing.";
                return response;
            }

            //Validate the format
            if (!MongoDB.Bson.ObjectId.TryParse(userID, out parsedUserID))
            {
                response.Success = false;
                response.ErrorCode = "2";
                response.ErrorDesc = "Field in incorrect format.";
                return response;
            }

            //Find the user
            var query =
                from u in collection.AsQueryable<User>()
                where u.id.Equals(parsedUserID) && u.SessionID == sessionID
                select u;

            List<User> users = query.ToList();
            if (users.Count() < 1)
            {
                response.Success = false;
                response.ErrorCode = "3";
                response.ErrorDesc = "Invalid user and/or session.";
                return response;
            }
            else
            {
                response.Success = true;
                response.FirstName = users[0].FirstName;
                response.LastName = users[0].LastName;
                response.Email = users[0].Email;
                response.HasCreditCard = (string.IsNullOrEmpty(users[0].CCNumber) ? false : true);
            }

            return response;
        }
    }
}
