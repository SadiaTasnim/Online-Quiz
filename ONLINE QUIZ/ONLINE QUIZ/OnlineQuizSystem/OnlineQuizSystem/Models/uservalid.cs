//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.ComponentModel.DataAnnotations;
//using OnlineQuizSystem.Models;
//using System.Web.Mvc;
//namespace OnlineQuizSystem.Models
//{
//    [MetadataType(typeof(UserMetadata))]
//    public class uservalid
//    {
//    }
//    public class UserMetadata
//    {
//        [Remote("isusernameavailable","TRegistration",ErrorMessage ="Username already in use")]
//        public string username { get; set; }
//    }
//}