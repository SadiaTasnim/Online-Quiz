//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineQuizSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ExamStudent
    {
        public int ExamineeID { get; set; }
        public string ID { get; set; }
        public Nullable<int> StuCategoryId { get; set; }
    
        public virtual Category Category { get; set; }
    }
}
