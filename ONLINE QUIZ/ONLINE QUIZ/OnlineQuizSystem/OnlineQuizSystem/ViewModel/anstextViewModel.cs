using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineQuizSystem.ViewModel
{
    [System.Runtime.InteropServices.Guid("DB0A2F9F-A345-42C8-8D21-CF777B5BE174")]
    public class anstextViewModel
    {
        public int questionId { get; set; }
        public int answerId { get; set; }
        public String questionText { get; set; }
        public String answerText { get; set; }
    }
}