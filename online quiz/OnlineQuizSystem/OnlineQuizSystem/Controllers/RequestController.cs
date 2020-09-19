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
    public class RequestController : Controller
    {
        ONLINEQUIZEntities8 db = new ONLINEQUIZEntities8();
        // GET: Request


        [HttpGet]
        //-------------------Not Added teacher list for student
        public ActionResult TeacherListForStudent()
        {

            int sID = Convert.ToInt32(Session["StudentId"]);
            String sql = "select * from Teacher where TeacherID not in" +
                " ( select Teacher.TeacherID from Teacher join FriendListForStudnet on " +
                "Teacher.TeacherID = FriendListForStudnet.teacherid where studentid = " + sID + ")";

            var data = db.Teachers.SqlQuery(sql).ToList();

            System.Diagnostics.Debug.WriteLine(data);


            ViewData["list"] = data;


            return View();
        }
        ///-----------------------------add a teacher -------------
        [HttpPost]
        public ActionResult TeacherListForStudentadd(int tid)
        {
            int sID = Convert.ToInt32(Session["StudentId"]);
            FriendListForStudnet AF = new FriendListForStudnet();
            AF.studentid = sID;
            AF.teacherid = tid;
            AF.timedate = DateTime.UtcNow.Date;
            db.FriendListForStudnets.Add(AF);
            db.SaveChanges();
            TempData["msg"] = "Friend successfully added!";

            return RedirectToAction("TeacherListForStudent");
        }

        ///-----------------------------showing others profile ------------
        public ActionResult Teacherprofileforstudent(string id)
        {

            int sID = Convert.ToInt32(Session["StudentId"]);


            var del = (from OnlineQuizSystem in db.Teachers
                       where OnlineQuizSystem.TeacherName == id
                       select OnlineQuizSystem).FirstOrDefault();



            return View(del);

        }

        public ActionResult Studentprofileforteacher(string id)
        {

            int sessId = Convert.ToInt32(Session["TeacherId"]);


            var del = (from OnlineQuizSystem in db.Students
                       where OnlineQuizSystem.StudentName == id
                       select OnlineQuizSystem).FirstOrDefault();



            return View(del);

        }

        ///-------------------showing teacher his friend list -----------
        public ActionResult Studentlistforteacher()
        {

            int sessId = Convert.ToInt32(Session["TeacherId"]);
            List<FriendListForStudnet> friendrequest = db.FriendListForStudnets.Where(x => x.teacherid == sessId && x.friendlist == 1).ToList();
            List<Student> addfriend = db.Students.ToList();

            ViewData["jointables"] = from fr in friendrequest
                                     join ad in addfriend on fr.studentid equals ad.StudentID into table1
                                     from ad in table1.DefaultIfEmpty()
                                     select new AcceptStudentRequestClass { friendrequest = fr, addfriend = ad };

            return View(ViewData["jointables"]);


        }

        ///-------------------------showing teacher his friend request-----------------------sadia
        [HttpGet]
        public ActionResult StudentRequestNotifictionForTeacher()
        {
            int sessId = Convert.ToInt32(Session["TeacherId"]);
            List<FriendListForStudnet> friendrequest = db.FriendListForStudnets.Where(x => x.teacherid == sessId && x.friendlist == 0).ToList();
            List<Student> addfriend = db.Students.ToList();

            ViewData["jointables"] = from fr in friendrequest
                                     join ad in addfriend on fr.studentid equals ad.StudentID into table1
                                     from ad in table1.DefaultIfEmpty()
                                     select new AcceptStudentRequestClass { friendrequest = fr, addfriend = ad };

            return View(ViewData["jointables"]);
        }
        [HttpPost]
        ///-------------------deleting friend request for teacher----------------
        public ActionResult StudentRequestNotifictionForTeacher(int sid, int delete)
        {
            int sessId = Convert.ToInt32(Session["TeacherId"]);
            var del = (from OnlineQuizSystem in db.FriendListForStudnets
                       where OnlineQuizSystem.studentid == sid && OnlineQuizSystem.teacherid == sessId
                       select OnlineQuizSystem).FirstOrDefault();
            if (delete == 1)
            {

                db.FriendListForStudnets.Remove(del);
                db.SaveChanges();
                TempData["msg"] = "Friend Request deleted";
            }



            return RedirectToAction("Studentlistforteacher");
        }
        ///---------------------------accepting friend request for teacher----------------------
        [HttpPost]
        public ActionResult StudentRequestNotifictionForTeacheraccept(int sid, int accept)
        {
            int sessId = Convert.ToInt32(Session["TeacherId"]);
            var del = (from OnlineQuizSystem in db.FriendListForStudnets
                       where OnlineQuizSystem.studentid == sid && OnlineQuizSystem.teacherid == sessId
                       select OnlineQuizSystem).FirstOrDefault();
            if (accept == 1)
            {

                del.friendlist = 1;
                db.SaveChanges();
                TempData["msg"] = "Friend Request accepted";
            }



            return RedirectToAction("StudentRequestNotifictionForTeacher");
        }

        ///--------------------friendlist showing for student------------------------

        public ActionResult FriendListForStudent()
        {
            int sID = Convert.ToInt32(Session["StudentId"]);

            List<FriendListForStudnet> friendlist = db.FriendListForStudnets.Where(x => x.studentid == sID && x.friendlist == 1).ToList();
            List<Teacher> teacherlist = db.Teachers.ToList();



            ViewData["jointabless"] = from fr in friendlist
                                      join ad in teacherlist on fr.teacherid equals ad.TeacherID into table1
                                      from ad in table1.DefaultIfEmpty()
                                      select new friendlistforstudent { friendlist = fr, teacherlist = ad };

            return View(ViewData["jointabless"]);


        }
        ///---------------------delete friend for student------------------------------------

        public ActionResult deletefrndforstudent(int tid, int delete)
        {
            int sessId = Convert.ToInt32(Session["StudentId"]);
            var del = (from OnlineQuizSystem in db.FriendListForStudnets
                       where OnlineQuizSystem.teacherid == tid && OnlineQuizSystem.studentid == sessId
                       select OnlineQuizSystem).FirstOrDefault();
            if (delete == 1)
            {

                db.FriendListForStudnets.Remove(del);
                db.SaveChanges();
                TempData["msg"] = "Friend deleted";
            }



            return RedirectToAction("FriendListForStudent", "Request");
        }

        ///-------------------------------requestsentforstudent-----------------------
        ///
        public ActionResult requestsentforstudent()
        {
            int sID = Convert.ToInt32(Session["StudentId"]);

            List<FriendListForStudnet> friendlist = db.FriendListForStudnets.Where(x => x.studentid == sID && x.friendlist == 0).ToList();
            List<Teacher> teacherlist = db.Teachers.ToList();



            ViewData["jointabless"] = from fr in friendlist
                                      join ad in teacherlist on fr.teacherid equals ad.TeacherID into table1
                                      from ad in table1.DefaultIfEmpty()
                                      select new friendlistforstudent { friendlist = fr, teacherlist = ad };

            return View(ViewData["jointabless"]);
        }


        ///-------------------deleting friend request for student---------------
        public ActionResult deleterequestsentforstudent(int tid, int delete)
        {
            int sessId = Convert.ToInt32(Session["StudentId"]);
            var del = (from OnlineQuizSystem in db.FriendListForStudnets
                       where OnlineQuizSystem.teacherid == tid && OnlineQuizSystem.studentid == sessId
                       select OnlineQuizSystem).FirstOrDefault();
            if (delete == 1)
            {

                db.FriendListForStudnets.Remove(del);
                db.SaveChanges();
                TempData["msg"] = "Friend Request deleted";
            }



            return RedirectToAction("requestsentforstudent", "Request");
        }

    }
}