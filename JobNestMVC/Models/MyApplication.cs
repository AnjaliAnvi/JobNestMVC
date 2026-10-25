using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobNestMVC.Models
{
    public class MyApplication
    {
        public int application_id { get; set; }
        public int job_id { get; set; }
        public string job_title { get; set; }
        public string Company { get; set; }
        public System.DateTime application_date { get; set; }
        public string status { get; set; }
    }
}