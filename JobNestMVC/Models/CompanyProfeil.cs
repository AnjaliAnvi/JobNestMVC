using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobNestMVC.Models
{
    public class CompanyProfeil
    {
        public string name { set; get; }
        public string email { set; get; }
        public string phone { set; get; }
        public string location { set; get; }
        public string description { set; get; }
        public string logo { set; get; }
        public string msg { set; get; }
    }
}