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
    public class SRegistrationController : Controller
    {
        ONLINEQUIZEntities8 db = new ONLINEQUIZEntities8();

        [HttpGet]
        public ActionResult StudentRegister()
        {
            return View();
        }

        [HttpPost]
        public ActionResult StudentRegister(Student stv)
        {
            if (stv.StudentName==null || stv.ID==null || stv.Passwords==null || stv.Email==null || stv.Department==null || stv.Semester==null || stv.Contact==null ||stv.Institute==null)
            {
               
                return RedirectToAction("StudentRegister", "SRegistration");
            }

            int count = db.Students.Where(u => u.StudentName== stv.StudentName).Count();

            if (count > 0)
            {

                return RedirectToAction("StudentRegister");
            }


            Student s = new Student();
            s.StudentName = stv.StudentName;
            s.ID = stv.ID;
            s.Passwords = stv.Passwords;
            s.Email = stv.Email;
            s.Department = stv.Department;
            s.Semester = stv.Semester;
            s.Contact = stv.Contact;
            s.Institute = stv.Institute;
            db.Students.Add(s);
            db.SaveChanges();
            return RedirectToAction("SLogin", "StudentLogin");
        }



    }
}