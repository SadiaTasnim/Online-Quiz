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

    public class NewCategoryController : Controller
    {
        ONLINEQUIZEntities8 db = new ONLINEQUIZEntities8();
        // GET: NewCategory
        public ActionResult NewCategory()
        {

            int tId = Convert.ToInt32(Session["TeacherId"]);
            CategoryViewModel objCategoryViewModel = new CategoryViewModel();

            objCategoryViewModel.ListofCategory = (from objCat in db.Categories

                                                   where objCat.CategoryTeacher == tId
                                                   select new SelectListItem()
                                                   {
                                                       Value = objCat.CategoryId.ToString(),
                                                       Text = objCat.CategoryName
                                                   }).ToList();



            return View(objCategoryViewModel);
        }
        [HttpPost]
        public JsonResult NewCategory(quesOptionViewModel quesOption)
        {
            Question objQuestion = new Question();
            objQuestion.Question_Text = quesOption.Question_Text;
            objQuestion.QuesCategoryId = quesOption.CategoryId;

            db.Questions.Add(objQuestion);
            db.SaveChanges();

            int questionid = objQuestion.QuestionID;

            foreach (var item in quesOption.ListOfOptions)
            {
                Option objOption = new Option();
                objOption.OptionName = item;
                objOption.OptQuesId = questionid;

                db.Options.Add(objOption);
                db.SaveChanges();


            }

            Answer objAns = new Answer();
            objAns.AnswerText = quesOption.AnswerText;
            objAns.AnsQuesId = questionid;
            db.Answers.Add(objAns);
            db.SaveChanges();



            return Json(data:new { message = "Question Successfully Added.", success = true }, JsonRequestBehavior.AllowGet);
        }
    }
}