using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobNestMVC.Models;

namespace JobNestMVC.Controllers
{
    public class JobPostController : Controller
    {
        JOBNESTMVCEntities dbobj = new JOBNESTMVCEntities();
        // GET: JobPost
        public ActionResult JobPost_PageLoad()
        {
            return View();
        }
        public ActionResult JobPost_InsertClick(JobPost clsobj)
        {
            if (ModelState.IsValid)
            {
               dbobj.sp_JobPosting(clsobj.title, clsobj.desc, clsobj.qualification, clsobj.skills, clsobj.experience, clsobj.salary, clsobj.location, clsobj.Jobtype, clsobj.jpdate, clsobj.jldate, clsobj.status, clsobj.company);
                clsobj.jmsg = "Inserted Successfully";
                return View("JobPost_PageLoad", clsobj);
            }
            return View("JobPost_PageLoad");
        }
        
    }
}