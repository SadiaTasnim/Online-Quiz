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
    public class SampleQuestionController : Controller
    {
        ONLINEQUIZEntities8 db = new ONLINEQUIZEntities8();
        // GET: SampleQuestion
        //public ActionResult showcategoryforstudent()
        //{
        //    int sID = Convert.ToInt32(Session["StudentId"]);


        //    String sql = "select * from Category where CategoryTeacher in (select FriendListForStudnet.teacherid from FriendListForStudnet join Teacher on FriendListForStudnet.teacherid = Teacher.TeacherID where studentid = " +sID+ " AND friendlist = 1)";


        //    var data = db.Categories.SqlQuery(sql).ToList();

        //    System.Diagnostics.Debug.WriteLine(data);


        //    ViewData["list"] = data;



        //    return View();
        //}


        //public ActionResult showsetsforstudent(int id)
        //{
        //    int sID = Convert.ToInt32(Session["StudentId"]);

        //    String sett = "select* from SetQuestion where SetID in (select Question.QuesSetId from Question join Category on Question.QuesCategoryId = Category.CategoryId where CategoryId = " + id + ")";




        //    var data = db.SetQuestions.SqlQuery(sett).ToList();

        //    System.Diagnostics.Debug.WriteLine(data);


        //    ViewData["list"] = data;

        //    return View();

        //}

        //public ActionResult showquestionsforstudent(int id)
        //{

        //    int sID = Convert.ToInt32(Session["StudentId"]);

        //    string set = "(select * from Question join SetQuestion on Question.QuesSetId=SetQuestion.SetID where SetID=" + id + ")";
        //    var data = db.Questions.SqlQuery(set).ToList();


        //    System.Diagnostics.Debug.WriteLine(data);



        //    ViewData["list"] = data;
        //    return View();
        //}
    }
}