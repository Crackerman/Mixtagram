using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Mixtagram_API.Models;

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
