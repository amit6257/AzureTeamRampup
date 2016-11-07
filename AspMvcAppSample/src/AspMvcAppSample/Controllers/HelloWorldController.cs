using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace AspMvcAppSample.Controllers
{
    public class HelloWorldController : Controller
    {
        // 
        // GET: /HelloWorld/
        // Index is the default method that will be called on a controller if a method name is not explicitly specified
        // try http://localhost:17734/HelloWorld OR http://localhost:17734/HelloWorld/index, same result
        public string Index()
        {
            return "This is my default action...";
        }

        // 
        // GET: /HelloWorld/Welcome/ 
        public string Welcome()
        {
            return "This is the Welcome action method...";
        }

        // http://localhost:17734/HelloWorld/Methodwithparams?name=tommy
        public string MethodWithParams(string name, int numTimes = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, numTimes: {numTimes}");
        }
    }
}
