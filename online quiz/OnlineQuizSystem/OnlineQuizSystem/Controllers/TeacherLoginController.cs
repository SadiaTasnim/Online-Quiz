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
    public class TeacherLoginController : Controller
    {
        ONLINEQUIZEntities8 db = new ONLINEQUIZEntities8();
        // GET: TeacherLogin
        [HttpGet]
        public ActionResult TLogin()  ///Teacher login page view
        {
            return View();
        }
        [HttpPost]
        public ActionResult TLogin(Teacher t) 
        {
            Teacher teach = db.Teachers.Where(x => x.TeacherName == t.TeacherName && x.Passwords == t.Passwords).SingleOrDefault();
            if (teach != null)
            {
                Session["TeacherID"] = teach.TeacherID;
                return RedirectToAction("TeacherProfile", "TeacherProfile");
            }
            else
                ViewBag.msg = "Invalid username or password";
            return View();
        }
    }
}