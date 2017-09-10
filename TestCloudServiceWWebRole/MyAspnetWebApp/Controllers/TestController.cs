using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyAspnetWebApp.Controllers
{
    public class TestController : ApiController
    {
        //public string Get()
        //{
        //    return "TestController Get() method";
        //}

        //public HttpResponseMessage Get()
        //{
        //    return Request.CreateResponse(HttpStatusCode.OK, "TestController Get() method with HttpResponseMessage as return type");
        //}

        [Authorize]
        public HttpResponseMessage Get()
        {
            // returns this message: "Message": "Authorization has been denied for this request."
            return Request.CreateResponse(HttpStatusCode.OK, "TestController Get() method with HttpResponseMessage as return type");
        }
    }
}
