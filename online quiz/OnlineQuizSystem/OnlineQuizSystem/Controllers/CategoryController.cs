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
    public class CategoryController : Controller
    {
        ONLINEQUIZEntities8 db = new ONLINEQUIZEntities8();
        // GET: Category
        [HttpGet]
        //------------------add category for teacher ---------
        public ActionResult Addcategory()
        {

            int tid = Convert.ToInt32(Session["TeacherID"].ToString());
            List<Category> li = db.Categories.Where(x => x.CategoryTeacher == tid).OrderByDescending(x => x.CategoryId).ToList();
            ViewData["list"] = li;

            return View();
        }
        [HttpPost] ///fetching and showing the inserted categories
          
        public ActionResult Addcategory(Category cat)
        {

            List<Category> li = db.Categories.OrderByDescending(x => x.CategoryId).ToList();
            ViewData["list"] = li;


            Category c = new Category();
            c.CategoryName = cat.CategoryName;
            c.CategoryTeacher = Convert.ToInt32(Session["TeacherID"].ToString());

            db.Categories.Add(c);
            db.SaveChanges();

            return RedirectToAction("Addcategory", "Category");
        }
 

    }
}