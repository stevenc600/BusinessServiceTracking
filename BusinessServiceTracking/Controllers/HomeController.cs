using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessServiceTracking.Controllers;
using BusinessServiceTracking.Helpers;
using BusinessServiceTracking.Models;

namespace BusinessServiceTracking.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

           // PerformCalcs.GetTableCount("employees", "Null");
          //  PerformCalcs.AddCost("employees", "null");
           

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

        public ActionResult Calcs()
        {

           



            return View();
        }
    }
}