using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace JobNestMVC.Models
{
    public class JobPost
    {
        [Required(ErrorMessage = "Enter Company Name")]
        public string company { set; get; }

        [Required(ErrorMessage = "Enter Job Title")]
        public string title { set; get; }

        [Required(ErrorMessage = "Enter Job Description")]
        public string desc { set; get; }

        [Required(ErrorMessage = "Enter Qualification")]
        public string qualification { set; get; }

        [Required(ErrorMessage = "Enter Skills")]
        public string skills { set; get; }

        [Required(ErrorMessage = "Enter experience")]
        public int experience { set; get; }

        [Required(ErrorMessage = "Enter Salary")]
        public string salary { set; get; }

        [Required(ErrorMessage = "Enter Location")]
        public string location { set; get; }

        [Required(ErrorMessage = "Enter Jobtype")]
        public string Jobtype { set; get; }

        [Required(ErrorMessage = "Select Posting Date")]
        [DataType(DataType.Date)]
        public DateTime jpdate { get; set; }

        [Required(ErrorMessage = "Select Last Date")]
        [DataType(DataType.Date)]
        public DateTime jldate { get; set; }

        [Required(ErrorMessage = "Status")]
        public string status { set; get; }

        public string jmsg { set; get; }
    }
}