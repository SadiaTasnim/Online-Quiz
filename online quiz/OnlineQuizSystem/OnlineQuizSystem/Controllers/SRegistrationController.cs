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
        // GET: SRegistration
        [HttpGet]
        public ActionResult StudentRegister()
        {
            return View();
        }

        [HttpPost]
        public ActionResult StudentRegister(Student stv)
        {
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

        //public string ImagePreview(HttpPostedFileBase imageFile) //image method
        //{
        //    string path = "-1";
        //    try
        //    {
        //        if (imageFile != null && imageFile.ContentLength > 0)
        //        {
        //            string extension = Path.GetExtension(imageFile.FileName);
        //            if (extension.ToLower().Equals("jpg") || extension.ToLower().Equals("jpeg") || extension.ToLower().Equals("png"))
        //            {
        //                Random r = new Random();

        //                path = Path.Combine(Server.MapPath("~/Content/image"), r + Path.GetFileName(imageFile.FileName));

        //                imageFile.SaveAs(path);

        //                path = "~/Content/image" + r + Path.GetFileName(imageFile.FileName);
        //            }
        //        }


        //    }
        //    catch (Exception)
        //    {

        //    }
        //    return path;
        //}

    }
}