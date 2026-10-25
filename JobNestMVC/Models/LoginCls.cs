using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace JobNestMVC.Models
{
    public class LoginCls
    {
        [Required(ErrorMessage = "Enter the username")]
        public string Uname { set; get; }

        [Required(ErrorMessage = "Enter password")]
        public string password { set; get; }

        public string msg { set; get; }
    }
}