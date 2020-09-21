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
using System.Security.Cryptography;

namespace OnlineQuizSystem.Controllers
{
    public class ReportController : Controller
    {
     
      
        // GET: Report

        private ONLINEQUIZEntities8 db;
        public ReportController()
        {
            db = new ONLINEQUIZEntities8();
        }
        public ActionResult Report()
        {
            return View();
        }
        [HttpGet]
        public ActionResult reportstudent()
        {
            return View();
        }

        //for student show students result 
        [HttpGet]
        public ActionResult SendResults()
        {

            int sID = Convert.ToInt32(Session["StudentId"]);

            List<Resultshow> res = db.Resultshows.Where(x => x.studentID == sID ).ToList();
            List<Category> cat = db.Categories.ToList();

            ViewData["jointables"] = from r in res
                                     join c in cat on r.QuesCategoryId equals c.CategoryId into table
                                     from c in table.DefaultIfEmpty()
                                     select new showsubjectnumberClass { CategoryName = c, marks = r ,CategoryId=c};

            return View(ViewData["jointables"]);


        }


        //show sample questions to student

        [HttpGet]
        public ActionResult showsamplequestions(int id)
        {


            List<Question> ques = db.Questions.Where(x => x.QuesCategoryId == id).ToList();
            
            List<Answer> ans = db.Answers.ToList();

            var allQuestionData = from que in ques
                                     join an in ans on que.QuesCategoryId equals an.AnsQuesId into table
                                     from an in table.DefaultIfEmpty()
                                     select new showsubjectnumberClass { ques_text =que,  catid = que,  quesid = que, anstext =an  ,ansquesid=an  };


            List<anstextViewModel> sv = new List<anstextViewModel>();
               

            foreach (var data in ques)
            {
                anstextViewModel sing = new anstextViewModel();
      
                Answer answer = db.Answers.Where(u => u.AnsQuesId == data.QuestionID).SingleOrDefault();
                //System.Diagnostics.Debug.WriteLine("Question  : " + data.QuestionID);
                //System.Diagnostics.Debug.WriteLine("Question Answer : " + answer.AnswerText);
                sing.answerId = answer.AnswerID;
                sing.answerText = answer.AnswerText;
                sing.questionId = data.QuestionID;
                sing.questionText = data.Question_Text;
                sv.Add(sing);
            }



            ViewData["jointables"] = sv;

            return View(ViewData["jointables"]);

        }



        // for teacher show his question names
        [HttpGet]
        public ActionResult ShowResultToTeacher()
        {
            if (Session["TeacherID"]==null)
            {
                return RedirectToAction("SLogin", "StudentLogin");
            }

            int tid = Convert.ToInt32(Session["TeacherID"].ToString());
            string set = "(select Distinct  CategoryId,CategoryName,CategoryTeacher,available from Category join Resultshow  on Category.CategoryId = Resultshow.QuesCategoryId where Category.CategoryTeacher = " + tid + ")";
            var data = db.Categories.SqlQuery(set).ToList();


            System.Diagnostics.Debug.WriteLine(data);



            ViewData["list"] = data;

            return View();
        }

        //----------student id's that gave exams---------
        [HttpGet]
        public ActionResult Showresultstudentid(int id )
        {
            

            List<Resultshow> res = db.Resultshows.Where(x => x.QuesCategoryId == id).ToList();

            List<Student> stu = db.Students.ToList();

            var allQuestionData = from r in res
                                  join s in stu on r.studentID  equals s.StudentID into table
                                  from s in table.DefaultIfEmpty()
                                  select new showsubjectnumberClass { resultstudID = r, marks = r, studentid = s, studentfullid = s};



            List<showsubjectnumberViewModel> sv = new List<showsubjectnumberViewModel>();

            
            foreach (var data in res)
            {
                showsubjectnumberViewModel sing = new showsubjectnumberViewModel();

                Student stud = db.Students.Where(u => u.StudentID == data.studentID).SingleOrDefault();
                //System.Diagnostics.Debug.WriteLine("Question  : " + data.QuestionID);
                //System.Diagnostics.Debug.WriteLine("Question Answer : " + answer.AnswerText);
                sing.studentid = stud.StudentID;
                sing.studentfullID = stud.ID;
                sing.resultstudentid = Convert.ToInt32( data.studentID);
                sing.totalmarks = Convert.ToInt32( data.totalmarks);
                sv.Add(sing);
            }



            ViewData["jointables"] = sv;
            return View(ViewData["jointables"]);
        }

        //----------student profile who gave exam --------
        public ActionResult Studentprofileofstudents(int id)
        {
            if (Session["TeacherID"] == null)
            {
                return RedirectToAction("SLogin", "StudentLogin");
            }

            int sessId = Convert.ToInt32(Session["TeacherId"]);


            var del = (from OnlineQuizSystem in db.Students
                       where OnlineQuizSystem.StudentID == id
                       select OnlineQuizSystem).FirstOrDefault();



            return View(del);

        }



    }
}