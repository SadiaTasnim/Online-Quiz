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
    public class QuizController : Controller
    {
        // GET: Quiz
        private ONLINEQUIZEntities8 db;
        public QuizController()
        {
            db = new ONLINEQUIZEntities8();
        }
 
        public ActionResult QuizStudent()
        {
            int sID = Convert.ToInt32(Session["StudentId"]);
            QuizCategoryViewModel objQuizViewModel = new QuizCategoryViewModel();


            objQuizViewModel.ListofCategory = (from objcat in db.Categories
                                             
                                               join objfrndlist in db.FriendListForStudnets on objcat.CategoryTeacher equals objfrndlist.teacherid
                                               where objfrndlist.studentid == sID && objfrndlist.friendlist == 1 && objcat.available ==1
                                               select new SelectListItem()
                                               {
                                                   Value = objcat.CategoryId.ToString(),
                                                   Text = objcat.CategoryName
                                               }).ToList();



            return View(objQuizViewModel);
        }



        [HttpPost]
        public ActionResult QuizStudent( int CategoryId)
        {
            int sID = Convert.ToInt32(Session["StudentId"]);

       

            IEnumerable<Question> qus = db.Questions.Where(u => u.QuesCategoryId == CategoryId);

            foreach ( var data in qus)
            {
                IEnumerable<Result> resultAll = db.Results
                           .Where(u => u.ResQuesId == data.QuestionID && u.ResStudent == sID);

                if (resultAll.Count() >= 1)
                {
                    return RedirectToAction("TLogin", "TeacherLogin");
                }

            }


            


            
            Session["StdQuestionAnswer"] = null;
            ExamStudent objstudent = new ExamStudent();
            objstudent.ID = Convert.ToString(sID);
            objstudent.StuCategoryId = CategoryId;
            
            db.ExamStudents.Add(objstudent);
            db.SaveChanges();
            Session["ID"] = sID;
            Session["StuCategoryId"] = CategoryId;
            Session["ExamineeID"] = objstudent.ExamineeID;
            return View("ExamStudent");

     
        }

        int pageNumber = 0;
        public PartialViewResult UserQuestionAnswer(StudentAnswer objStudentAnswer)
        {
            bool IsLast = false;
            if(objStudentAnswer.AnswerText != null)
            {
                List<StudentAnswer> objstudentAnswers = Session["StdQuestionAnswer"] as List<StudentAnswer>;
                if(objstudentAnswers== null)
                {
                    objstudentAnswers = new List<StudentAnswer>();
                }
                objstudentAnswers.Add(objStudentAnswer);
                Session["StdQuestionAnswer"] = objstudentAnswers;
            }

            int pageSize = 1;
            pageNumber = 0;
            int CategoryId = Convert.ToInt32(Session["StuCategoryId"]);

            if(Session["StdQuestionAnswer"] == null)
            {
                pageNumber = pageNumber + 1;
            }
            else
            {
                List<StudentAnswer> canAnswer = Session["StdQuestionAnswer"] as List<StudentAnswer>;
                pageNumber = canAnswer.Count + 1;
            }
            List<Question> listOfQuestion = new List<Question>();
            listOfQuestion = db.Questions.Where(model => model.QuesCategoryId == CategoryId).ToList();
            System.Diagnostics.Debug.WriteLine(listOfQuestion.Count);
            if (pageNumber == listOfQuestion.Count)
            {
                IsLast = true;
            }

            QuizAnswerViewModel objAnsViewModel = new QuizAnswerViewModel();
            Question objQuestion = new Question();
            /*objQuestion = listOfQuestion.Skip((pageNumber - 1) * pageSize).Take(pageSize).FirstOrDefault()*/;
            System.Diagnostics.Debug.WriteLine("pagenumber = "+pageNumber);
            if(listOfQuestion.Count < pageNumber)
            {
                return PartialView("asdasd");
            }
            objQuestion = listOfQuestion[pageNumber - 1];
                
            

           


            objAnsViewModel.IsLast = IsLast;
            objAnsViewModel.QuestionID = objQuestion.QuestionID;
            objAnsViewModel.Question_Text = objQuestion.Question_Text;

           


            objAnsViewModel.ListOfQuizOption = (from obj in db.Options
                                                where obj.OptQuesId == objQuestion.QuestionID
                                                select new QuizOption()
                                                {
                                                    OptionName = obj.OptionName,
                                                    OptionID = obj.OptionID
                                                }).ToList();


            bool isOK = true;
            int sID = Convert.ToInt32(Session["StudentId"]);

            Category qus = db.Categories.Find(CategoryId);
            if (qus.available == 0)
            {
                isOK = false;

                Resultshow showresult = new Resultshow();
                showresult.studentID = sID;
                showresult.QuesCategoryId = qus.CategoryId;
                showresult.totalmarks = 0;
                db.Resultshows.Add(showresult);
                db.SaveChanges();

            }

            ViewBag.isAvabil = isOK;

            System.Diagnostics.Debug.WriteLine(objAnsViewModel.QuestionID + "");
            return PartialView("QuizQuestionOption", objAnsViewModel);
        }

        public JsonResult SaveStudentAnswer(StudentAnswer objStudentAnswer)
        {
            List<StudentAnswer> canAnswer = Session["StdQuestionAnswer"] as List<StudentAnswer>;
            if (objStudentAnswer.AnswerText != null)
            {
                List<StudentAnswer> objstudentAnswers = Session["StdQuestionAnswer"] as List<StudentAnswer>;
                if (objstudentAnswers == null)
                {
                    objstudentAnswers = new List<StudentAnswer>();
                }
                objstudentAnswers.Add(objStudentAnswer);
                Session["StdQuestionAnswer"] = objstudentAnswers;
            }
            System.Diagnostics.Debug.WriteLine(" canAnswer " + canAnswer.Count);
            foreach (var item in canAnswer)
            {
                Result objResult = new Result();
                objResult.AnswerText = item.AnswerText;
                objResult.ResQuesId = item.QuestionID;
                objResult.ResStudent = Convert.ToInt32(Session["StudentID"]);
            
                db.Results.Add(objResult);
                db.SaveChanges();
            }
            return Json(data: new { message = "Answer Successfully Added.", success = true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetFinalResult()
        {
            List<StudentAnswer> listOfQuestionAnswers;
            listOfQuestionAnswers = Session["StdQuestionAnswer"] as List<StudentAnswer>;

            var UserResult = (from objResult in listOfQuestionAnswers
                              join objAnswer in db.Answers on objResult.QuestionID equals objAnswer.AnsQuesId
                              join objQuestion in db.Questions on objResult.QuestionID equals objQuestion.QuestionID
                              select new ResultModel()
                              {
                                  
                                  Question = objQuestion.Question_Text,
                                  Answer = objAnswer.AnswerText,
                                  AnswerByStudent = objResult.AnswerText,
                                  Status = objAnswer.AnswerText == objResult.AnswerText ? "Correct" : "Wrong" ,
                                  
                             
                                  
                              }).ToList();





            //start



            int studnetId = Convert.ToInt32(Session["StudentId"]);
            int quizCatId = Convert.ToInt32(Session["StuCategoryId"]);



            if (studnetId == 0 || quizCatId == 0)
            {
                return RedirectToAction("Report", "Report");
            }
            IEnumerable<Category> cat = db.Categories.ToList();
            int count = 0;
            foreach (var allCat in cat)
            {

                if (allCat.CategoryId == quizCatId)
                {

                    IEnumerable<Question> catQues = db.Questions.Where(q => q.QuesCategoryId == allCat.CategoryId);

                    List<Result> results = new List<Result>();
                    foreach (var data in catQues)
                    {
                        IEnumerable<Result> resultAll = db.Results
                            .Where(u => u.ResQuesId == data.QuestionID && u.ResStudent == studnetId);
                       
                        if (resultAll.Count() >= 2)
                        {
                            return RedirectToAction("TLogin", "TeacherLogin");
                        }
                        Result resultSingle = resultAll.First();

                        if (resultSingle != null)
                            results.Add(resultSingle);
                    }

                    if (results.Count <= 0)
                    {
                        return RedirectToAction("TLogin", "TeacherLogin");
                    }

                    System.Diagnostics.Debug.WriteLine(results.Count);
                    foreach (var data in results)
                    {
                        int a = (int)data.ResQuesId;
                        Question ResQues = db.Questions.Where(q => q.QuestionID == a).Single();
                        //System.Diagnostics.Debug.WriteLine("ResultID = " + ResQues.QuestionID);
                        Answer QuesAns = db.Answers.Where(q => q.AnsQuesId == ResQues.QuestionID).Single();

                        //System.Diagnostics.Debug.WriteLine("Student AnswerText = " + data.AnswerText);
                        //System.Diagnostics.Debug.WriteLine("Corrent ResultID = " + QuesAns.AnswerText);
                        System.Diagnostics.Debug.WriteLine(data.AnswerText + "  " + QuesAns.AnswerText);
                        if (data.AnswerText == QuesAns.AnswerText)
                            count++;


                    }
                    System.Diagnostics.Debug.WriteLine(count);
                    break;
                }

            }
            ViewBag.studentId = studnetId;
            ViewBag.quizCatId = quizCatId;

            ViewBag.student = db.Students.Find(studnetId);
            Category category = db.Categories.Find(quizCatId);
            if (category == null)
            {
           

                return RedirectToAction("DashBoard", "Check");
            }
            ViewBag.category = category;
            ViewBag.Count = count;



            Resultshow showresult = new Resultshow();
            showresult.studentID = studnetId;
            showresult.QuesCategoryId = quizCatId;
            showresult.totalmarks = count;
            db.Resultshows.Add(showresult);
            db.SaveChanges();
            pageNumber = -1;


            //end

            return View(UserResult);
        }


        // https://localhost:44348/Quiz/SendResult?studnetId=1&quizCatId=6
        public ActionResult SendResult()
        {
          

            int studnetId = Convert.ToInt32(Session["StudentId"]);
            int quizCatId = Convert.ToInt32(Session["StuCategoryId"]);



            if (studnetId == 0 || quizCatId == 0)
            {
                return RedirectToAction("Report", "Report");
            }
            IEnumerable<Category> cat = db.Categories.ToList();
            int count = 0;
            foreach (var allCat in cat)
            {

                if(allCat.CategoryId == quizCatId)
                {

                    IEnumerable<Question> catQues = db.Questions.Where(q => q.QuesCategoryId == allCat.CategoryId);

                    List<Result> results = new List<Result>();
                    foreach (var data in catQues)
                    {
                        Result resultSingle = db.Results
                            .Where(u => u.ResQuesId == data.QuestionID && u.ResStudent == studnetId).SingleOrDefault();
                        if(resultSingle != null)
                            results.Add(resultSingle);
                    }

                    if (results.Count <= 0)
                    {
                        return RedirectToAction("TLogin", "TeacherLogin");
                    }

                    System.Diagnostics.Debug.WriteLine(results.Count);
                    foreach (var data in results)
                    {
                        int a = (int)data.ResQuesId;
                        Question ResQues = db.Questions.Where(q => q.QuestionID == a).Single();
                        //System.Diagnostics.Debug.WriteLine("ResultID = " + ResQues.QuestionID);
                        Answer QuesAns = db.Answers.Where(q => q.AnsQuesId == ResQues.QuestionID).Single();

                        //System.Diagnostics.Debug.WriteLine("Student AnswerText = " + data.AnswerText);
                        //System.Diagnostics.Debug.WriteLine("Corrent ResultID = " + QuesAns.AnswerText);
                        System.Diagnostics.Debug.WriteLine(data.AnswerText +"  "+ QuesAns.AnswerText);
                        if (data.AnswerText == QuesAns.AnswerText)
                            count++;

                       
                    }
                    System.Diagnostics.Debug.WriteLine(count);
                    break;
                }

            }
            ViewBag.studentId = studnetId;
            ViewBag.quizCatId = quizCatId;

            ViewBag.student = db.Students.Find(studnetId);
            Category category = db.Categories.Find(quizCatId);
            if (category == null)
            {

                return RedirectToAction("DashBoard", "Check");
            }
            ViewBag.category = category;
            ViewBag.Count = count;



            Resultshow showresult = new Resultshow();
            showresult.studentID = studnetId;
            showresult.QuesCategoryId = quizCatId;
            showresult.totalmarks = count;
            db.Resultshows.Add(showresult);
            db.SaveChanges();


            return View();
        }
    }
}