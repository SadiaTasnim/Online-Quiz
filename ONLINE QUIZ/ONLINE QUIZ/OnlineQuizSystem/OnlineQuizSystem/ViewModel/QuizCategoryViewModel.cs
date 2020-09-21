using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace OnlineQuizSystem.ViewModel
{
    public class QuizCategoryViewModel
    {
        [Display(Name ="Course Name")]
        [Required(ErrorMessage ="Course name is Required")]
        public int CategoryId { get; set; }
        [Display(Name = "Examinee Name")]
        [Required(ErrorMessage = "Examinee name is Required")]
        public int ExamineeID { get; set; }
        public string ExamineeName { get; set; }
        [Display(Name = "Examinee ID")]
        [Required(ErrorMessage = "Examinee ID is Required")]
        public string ID { get; set; }

        public int StudentID { get; set; }

        public int friendlist { get; set; }

        

        public IEnumerable<SelectListItem> ListofCategory { get; set; }



    }
}