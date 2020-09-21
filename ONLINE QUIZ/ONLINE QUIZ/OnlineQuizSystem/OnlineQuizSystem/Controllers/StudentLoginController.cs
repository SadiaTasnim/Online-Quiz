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
    public class StudentLoginController : Controller
    {
        ONLINEQUIZEntities8 db = new ONLINEQUIZEntities8();
        // GET: StudentLogin

        [HttpGet]
        public ActionResult SLogin() ///Student login page view
        {
            return View();
        }

        [HttpPost]
        public ActionResult SLogin(Student s)
        {
            Student stu = db.Students.Where(x => x.Email == s.Email && x.Passwords == s.Passwords && x.ID == s.ID).SingleOrDefault();
            if (stu == null)
            {
                ViewBag.msg = "Invalid username or ID or password";
                ViewBag.color = "red";
            }
            else
            {
                Session["StudentId"] = stu.StudentID;
                Session["StudentIdText"] = stu.ID;
                return RedirectToAction("StudentProfile", "StudentProfile");
                ///works to be done
            }
            return View();
        }
    }
}