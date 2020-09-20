using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace OnlineQuizSystem.ViewModel
{
    public class CategoryViewModel
    {
        [Display(Name ="Subject")]
        [Required(ErrorMessage = "Subject Category is required.")]
        public int CategoryId { get; set; }
        public int TeacherId { get; set; }
        public int SetID { get; set; }

        [Display(Name = "Set Number")]
        [Required(ErrorMessage = "Set No. is required.")]
        public string SetNumber { get; set; }

        public string SetDate { get; set; }
        [Display(Name = "Question")]

        [Required(ErrorMessage = "Question is required.")]
        public string Question_Text { get; set; }
        [Display(Name = "Options")]
        public string OptionName { get; set; }
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
        public string AnswerText { get; set; }

        public IEnumerable<SelectListItem> ListofCategory { get; set; }

        public IEnumerable<SelectListItem> ListOfSets { get; set; }

        public IEnumerable<SelectListItem> showquestions { get; set; }

    }
}