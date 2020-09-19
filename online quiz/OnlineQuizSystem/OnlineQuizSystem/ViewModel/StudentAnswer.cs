using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineQuizSystem.ViewModel
{
    public class StudentAnswer
    {
        //public int ResQuesId { get; set; }
        public int QuestionID { get; set; }

        public int QuesCategoryId { get; set; }
        public string Question_Text { get; set; }

        public string AnswerText { get; set; }
        //public int total { get; set; }

    }
}