﻿using OnlineQuizSystem.Models;
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
            
                Teacher t = new Teacher();
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