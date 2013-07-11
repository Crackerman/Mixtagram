using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;

namespace Mixtagram_API.HelperClasses
{
    public class Database
    {
        public static MongoDatabase GetMixtagramDatabase()
        {
            /*
            var credential = MongoCredential.CreateMongoCRCredential("test", "user1", "password1");
            var settings = new MongoClientSettings
            {
                Credentials = new[] { credential }
            };
            var mongoClient = new MongoClient(settings);
            */
            var connectionString = ConfigurationManager.AppSettings["MixtagramDBConnection"].ToString();
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            return server.GetDatabase("mixtagram");
        }
    }
}