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
    
    public partial class Option
    {
        public int OptionID { get; set; }
        public Nullable<int> OptQuesId { get; set; }
        public string OptionName { get; set; }
    
        public virtual Question Question { get; set; }
    }
}