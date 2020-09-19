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
    public class TeacherProfileController : Controller
    {
        ONLINEQUIZEntities8 db = new ONLINEQUIZEntities8();

        [HttpGet]
        public ActionResult TeacherProfile()
        {
            int teacherId = Convert.ToInt32(Session["TeacherID"]);
            if(teacherId==0)
            {
                return RedirectToAction("TLogin", "TeacherLogin");
            }
            return View(db.Teachers.Find(teacherId));
        }

       
    }
}