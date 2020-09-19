using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineQuizSystem.ViewModel
{
    public class quesOptionViewModel
    {
       public int CategoryId { get; set; }
        public string Question_Text { get; set; }
        public List<string> ListOfOptions { get; set; }
        public string AnswerText { get; set; }
        public int SetID { get; set; }


    }
   
}