using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyAspnetWebApp.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        //public IEnumerable<string> Get1()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        public string Get()
        {
            return "get method";
        }

        // GET api/values/5
        //public string Get(int id)
        //{
        //    return "value passed = " + id;
        //}

        public object Get(int id)
        {
            return new
            {
                id = id,
                str = "yo"
            };
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
