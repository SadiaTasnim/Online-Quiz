using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using OnlineQuizSystem.Models;

namespace OnlineQuizSystem.Models
{
    public class UserTeacher
    {
        [Required(ErrorMessage ="Enter your full name!")]
        [Display(Name ="Full Name:")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Enter your user name!")]
        [Display(Name = "User Name:")]
        [StringLength(maximumLength:10,MinimumLength =3,ErrorMessage ="Username length must be Max 10 & Min 3")]
        public string TeacherName { get; set; }

        [Required(ErrorMessage = "Please enter your Email address!")]
        [Display(Name = "Email ID:")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your password!")]
        [Display(Name = "Password:")]
        [DataType(DataType.Password)]
        [StringLength(maximumLength: 15, MinimumLength = 5, ErrorMessage = "Password length must be Max 15 & Min 5")]
        public string Passwords { get; set; }

        [Required(ErrorMessage = "Please enter your password again to confirm!")]
        [Display(Name = "Confirm Password:")]
        [DataType(DataType.Password)]
        [Compare("Passwords", ErrorMessage ="Password did not match")]
        public string RePassword { get; set; }

        [Required(ErrorMessage = "Please enter your institution name!")]
        [Display(Name = "Institution Name:")]
        public string Institute { get; set; }

        [Required(ErrorMessage = "Please enter your designation!")]
        [Display(Name = "Designation:")]
        public string Designation { get; set; }

        [Required(ErrorMessage = "Please enter your Contact number!")]
        [Display(Name = "Contact No.:")]
        public string Contact { get; set; }

        //[Required(ErrorMessage = "Upload Profile Image")]
        //[Display(Name = "Profile Image:")]
        //public string TeacherImage { get; set; }


    }
}