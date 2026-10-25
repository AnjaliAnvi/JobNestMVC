using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobNestMVC.Models
{
    public class JobDetails
    {
        public int job_id { get; set; }

        public string job_title { get; set; }

        public string description { get; set; }

        public string qualification { get; set; }

        public string skills { get; set; }

        public int experience { get; set; }

        public string salary { get; set; }

        public string location { get; set; }

        public string job_type { get; set; }

        public DateTime posted_date { get; set; }

        public DateTime last_date { get; set; }

        public string status { get; set; }

        public string Company { get; set; }

        
    }
}
