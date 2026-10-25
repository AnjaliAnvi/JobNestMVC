using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace JobNestMVC.Models
{
    public class checkBoxHelper
    {
        public string value { set; get; }
        public string text { set; get; }

        public Boolean valuecheck { set; get; }
    }
    public class InsertClass
    {
        public int uid { set; get; }

        [Required(ErrorMessage = "Enter the Name")]
        public string name { set; get; }

        [EmailAddress(ErrorMessage = "Enter valid email id")]
        public string email { set; get; }

        [Required(ErrorMessage = "Enter the Phone")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Enter valid number")]
        public string phone { set; get; }

        [Required(ErrorMessage = "Enter the Location")]
        public string location { set; get; }

        public List<checkBoxHelper> Myfavqual { set; get; } = new List<checkBoxHelper>();
        public string[] selectedqul { set; get; }

        public string qualification { set; get; }

        [Required(ErrorMessage = "Enter the Experinece ")]
        public int experience { set; get; }

        public string resume { set; get; }
        public string photo { set; get; }
        public string username { set; get; }

        public string pass { set; get; }
        [Compare("pass", ErrorMessage = "Password mismatch")]

        public string cpassword { set; get; }

        public string usermsg { set; get; }

    }
}