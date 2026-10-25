using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace JobNestMVC.Models
{
    public class AdminInsert
    {
        public int uid { set; get; }

        [Required(ErrorMessage = "Enter the Company Name")]
        public string name { set; get; }

        [EmailAddress(ErrorMessage = "Enter valid email id")]
        public string email { set; get; }

        [Required(ErrorMessage = "Enter the Phone")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Enter valid number")]
        public string phone { set; get; }

        [Required(ErrorMessage = "Enter the Location")]
        public string location { set; get; }

        [Required(ErrorMessage = "Description about company")]
        public string description { set; get; }

        public string logo { set; get; }

        public string username { set; get; }

        public string password { set; get; }
        [Compare("password", ErrorMessage = "Password mismatch")]

        public string cpassword { set; get; }

        public string cmsg { set; get; }
    }
}