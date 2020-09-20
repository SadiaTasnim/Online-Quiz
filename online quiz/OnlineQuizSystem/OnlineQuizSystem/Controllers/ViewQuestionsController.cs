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
   
    public class ViewQuestionsController : Controller
    {
        ONLINEQUIZEntities8 db = new ONLINEQUIZEntities8();


        [HttpGet]
        public ActionResult ViewQuestion()
        {
            int sessId = Convert.ToInt32(Session["TeacherId"]);
            List<Category> cat = db.Categories.Where(x => x.CategoryTeacher == sessId).ToList();

            ViewData["list"] = cat;
            return View();
            
        }

   
        [HttpGet]
        public ActionResult showquestions(int id)
        {
            List<Question> ques = db.Questions.Where(x => x.QuesCategoryId == id).ToList();

            List<Answer> ans = db.Answers.ToList();

            var allQuestionData = from que in ques
                                  join an in ans on que.QuesCategoryId equals an.AnsQuesId into table
                                  from an in table.DefaultIfEmpty()
                                  select new showsubjectnumberClass { ques_text = que, catid = que, quesid = que, anstext = an, ansquesid = an };


            List<anstextViewModel> sv = new List<anstextViewModel>();


            foreach (var data in ques)
            {
                anstextViewModel sing = new anstextViewModel();
                Answer answer = db.Answers.Where(u => u.AnsQuesId == data.QuestionID).SingleOrDefault();
                System.Diagnostics.Debug.WriteLine("Question  : " + data.QuestionID);
                System.Diagnostics.Debug.WriteLine("Question Answer : " + answer.AnswerText);
                sing.answerId = answer.AnswerID;
                sing.answerText = answer.AnswerText;
                sing.questionId = data.QuestionID;
                sing.questionText = data.Question_Text;
                sv.Add(sing);
            }


            ViewData["jointables"] = sv;
      
            return View(ViewData["jointables"]);

        }

        [HttpPost]
        public ActionResult makeavailbe(int cid ,int available)
        {

            var del = (from OnlineQuizSystem in db.Categories
                       where OnlineQuizSystem.CategoryId == cid
                       select OnlineQuizSystem).FirstOrDefault();


            int questionCount = db.Questions.Where(u => u.QuesCategoryId == cid).Count();

            //if (questionCount <= 1)
            //{

            //    return RedirectToAction("ViewQuestion");
            //}

            if (available == 1)
            {

                if (questionCount > 1)
                {
                    del.available = 1;
                    db.SaveChanges();
                    //ViewBag.msg = "Available For Student";
                }
                //else
                //    ViewBag.msg = "Please Insert more Questions.";


            }
            else
            {

                del.available = 0;
                db.SaveChanges();
                //ViewBag.msg = "Not Available For Student";
            }

            //System.Diagnostics.Debug.WriteLine(del.available);

            return RedirectToAction("ViewQuestion");
        }


        //public ActionResult deleteques(int delete,int qid)
        //{
        //    int sessId = Convert.ToInt32(Session["TeacherId"]);

        //    var del = (from OnlineQuizSystem in db.Results
        //               where OnlineQuizSystem.ResQuesId == qid
        //               select OnlineQuizSystem).FirstOrDefault();


        //    if (delete==1)
        //    {
        //        db.Results.Remove(del);
        //        db.SaveChanges();
        //    }

        //    var del1 = (from OnlineQuizSystem in db.Answers
        //               where OnlineQuizSystem.AnsQuesId == qid
        //               select OnlineQuizSystem).FirstOrDefault();

        //    if (delete == 1)
        //    {
        //        db.Answers.Remove(del1);
        //        db.SaveChanges();
        //    }

        //    //var del2 = (from OnlineQuizSystem in db.Options
        //    //            where OnlineQuizSystem.OptQuesId == qid
        //    //            select OnlineQuizSystem).FirstOrDefault();


        //    //foreach(var data in db.Options)
        //    //{
        //    //    db.Options.Remove(del2);
        //    //    db.SaveChanges();
        //    //}
        //    ////if (delete == 1)
        //    ////{

        //    ////}
        //    ///

        //    string set = "(delete * from Options where OptQuesId = " + qid + " )";
        //    var data = db.Options.SqlQuery(set).ToList();



        //    var del3 = (from OnlineQuizSystem in db.Questions
        //                where OnlineQuizSystem.QuestionID == qid
        //                select OnlineQuizSystem).FirstOrDefault();

        //    if (delete == 1)
        //    {
        //        db.Questions.Remove(del3);
        //        db.SaveChanges();
        //        ViewBag.msg = "Question Deleted";
        //    }


        //    return RedirectToAction("showquestions");
        //}

    }
}