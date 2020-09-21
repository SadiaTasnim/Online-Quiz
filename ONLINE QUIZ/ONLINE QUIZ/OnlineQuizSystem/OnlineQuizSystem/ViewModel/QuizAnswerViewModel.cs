using OnlineQuizSystem.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineQuizSystem.ViewModel
{
    public class QuizAnswerViewModel
    {
        public bool IsLast { get; set; }
        public int OptionID { get; set; }
        public string OptionName { get; set; }
        public int QuestionID { get; set; }
        public string Question_Text { get; set; }
        public List<QuizOption> ListOfQuizOption { get; set; }
    }
    public class QuizOption
    {
        public int OptionID { get; set; }
        public string OptionName { get; set; }
    }
}