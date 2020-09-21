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
    public class StudentProfileController : Controller
    {
        ONLINEQUIZEntities8 db = new ONLINEQUIZEntities8();

        [HttpGet]
        public ActionResult StudentProfile()
        {
            int studentId = Convert.ToInt32(Session["StudentID"]);
            if (studentId == 0)
            {
                return RedirectToAction("SLogin", "StudentLogin");
            }
            return View(db.Students.Find(studentId));
            
        }
    }
}