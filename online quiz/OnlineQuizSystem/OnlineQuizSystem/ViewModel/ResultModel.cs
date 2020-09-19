using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineQuizSystem.ViewModel
{
    public class ResultModel
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public string AnswerByStudent { get; set; }
        public string Status { get; set; }

        
    }
}