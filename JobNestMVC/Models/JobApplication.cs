using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobNestMVC.Models
{
    public class JobApplication
    {
        public int job_id { get; set; }

        public string name { get; set; }

        public int experience { get; set; }

        public string location { get; set; }

        public string skills { get; set; }

        public string resume { get; set; }
    }
}