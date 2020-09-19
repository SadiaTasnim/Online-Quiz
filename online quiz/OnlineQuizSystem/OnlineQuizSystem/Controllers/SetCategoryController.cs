using OnlineQuizSystem.Models;
using OnlineQuizSystem.ViewModel;
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
    public class SetCategoryController : Controller
    {
        //ONLINEQUIZEntities7 db = new ONLINEQUIZEntities7();
        ////GET: SetCategory
        //[HttpGet]
        //public ActionResult SetCatQues()
        //{
        //    int setid = Convert.ToInt32(Session["TeacherID"].ToString());
        //    ///for limiting the data fetching through dfrnt teachers
        //    List<SetQuestion> li = db.SetQuestions.Where(x => x.SetTeacher == setid).OrderByDescending(x => x.SetID).ToList();
        //    ViewData["list"] = li;
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult SetCatQues(SetQuestion setq)
        //{
        //    List<SetQuestion> li = db.SetQuestions.OrderByDescending(x => x.SetID).ToList();
        //    ViewData["list"] = li;


        //    SetQuestion s = new SetQuestion();
        //    s.SetNumber = setq.SetNumber;
        //    s.SetTeacher = Convert.ToInt32(Session["TeacherID"].ToString());

        //    db.SetQuestions.Add(s);
        //    db.SaveChanges();

        //    return RedirectToAction("SetCatQues", "SetCategory");

        //}



    }
}