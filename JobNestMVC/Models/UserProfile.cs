using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobNestMVC.Models
{
    public class UserProfile
    {
        public string name { set; get; }
        public string email { set; get; }
        public string phone { set; get; }
        public string location { set; get; }
        public string qualification { set; get; }
        public int experience { set; get; }
        public string resume { set; get; }
        public string photo { set; get; }

        public string msg{set; get;}

    }
}