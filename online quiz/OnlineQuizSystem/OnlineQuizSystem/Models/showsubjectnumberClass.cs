using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineQuizSystem.Models
{
    public class showsubjectnumberClass
    {
        public Category CategoryName { get; set; }

        public Category CategoryId { get; set; }

        public Resultshow marks { get; set; }

        public Resultshow resultstudID { get; set; }

        public Student studentname { get; set; }

        public Student studentid { get; set; }

        public Student studentfullid { get; set; }
        public Question catid { get; set; }

        public Question quesid { get; set; }

        public Question ques_text { get; set; }

        public Answer anstext { get; set; }

        public Answer ansquesid { get; set; }
    }
}