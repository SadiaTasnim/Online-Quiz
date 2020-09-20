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
    public class TRegistrationController : Controller
    {
        ONLINEQUIZEntities8 db = new ONLINEQUIZEntities8();

        [HttpGet]
        public ActionResult TeacherRegister()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TeacherRegister(Teacher tch)
        {
            if (tch.FullName==null || tch.Email==null || tch.TeacherName == null || tch.Passwords == null || tch.FullName == null || tch.Institute == null || tch.Designation== null)
            {
              
                return RedirectToAction("TeacherRegister", "TRegistration");
            }

            int count = db.Teachers.Where(u => u.TeacherName == tch.TeacherName).Count();

            if (count > 0)
            {

                return RedirectToAction("TeacherRegister");
            }

            //if (ModelState.IsValid)
            //{
            //    var isUserexist = db.Teachers.Any(u => u.TeacherName == tch.TeacherName);
            //    if (isUserexist)
            //    {
            //        ModelState.AddModelError("TeacherName", "This user name already exists");
            //        return View(tch);
            //    }
            //    Teacher t = new Teacher();
            //    t.FullName = tch.FullName;
            //    t.Email = tch.Email;
            //    t.TeacherName = tch.TeacherName;
            //    t.Passwords = tch.Passwords;
            //    t.FullName = tch.FullName;
            //    t.Institute = tch.Institute;
            //    t.Designation = tch.Designation;
            //    t.Contact = tch.Contact;
            //    db.Teachers.Add(t);
            //    db.SaveChanges();
            //}

            Teacher t = new Teacher();
            t.FullName = tch.FullName;
            t.Email = tch.Email;
            t.TeacherName = tch.TeacherName;
            t.Passwords = tch.Passwords;
            t.FullName = tch.FullName;
            t.Institute = tch.Institute;
            t.Designation = tch.Designation;
            t.Contact = tch.Contact;
            db.Teachers.Add(t);
            db.SaveChanges();

            return RedirectToAction("TLogin", "TeacherLogin");
        }
        
      

    }
}