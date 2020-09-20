 using OnlineQuizSystem.Models;
using System;

using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace OnlineQuizSystem.Controllers
{
    public class HomeController : Controller
    {
        ONLINEQUIZEntities8 db = new ONLINEQUIZEntities8();

        public ActionResult Teacherprofileforstudent()
        {

            return View();
        }

        ///------------------------student's profile what a teacher can see -----------------------------///sadia
        public ActionResult Studentprofileforteacher()
        {

            return View();
        }





        ///---------------------------Home Page------------------------------

        public ActionResult Index()
        {
            if(Session["TeacherId"]!= null)
            {
                return RedirectToAction("DashBoard", "Check");
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Home()
        {
       

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}