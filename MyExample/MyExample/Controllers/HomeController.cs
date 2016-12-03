using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

// http://myexample20161202071101.azurewebsites.net/ this is the link
// https://docs.microsoft.com/en-us/azure/app-service-web/web-sites-dotnet-get-started This is the tutorial for this app

namespace MyExample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}