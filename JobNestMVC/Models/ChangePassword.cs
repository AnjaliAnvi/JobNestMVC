using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace JobNestMVC.Models
{
    public class ChangePassword
    {
        public string oldpwd { set; get; }
        public string newpwd { set; get; }

        public string confirmpwd { set; get; }
        public string msg { set; get; }
    }
}