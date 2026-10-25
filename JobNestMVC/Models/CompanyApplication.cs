using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobNestMVC.Models
{
    public class CompanyApplication
    {
        public int application_id { get; set; }
        public int job_id { get; set; }
        public string job_title { get; set; }
        public int user_id { get; set; }
        public string name { get; set; }
        public int experience { get; set; }
        public string location { get; set; }
        public string skills { get; set; }
        public string resume { get; set; }
        public System.DateTime application_date { get; set; }
        public string status { get; set; }
    }
}