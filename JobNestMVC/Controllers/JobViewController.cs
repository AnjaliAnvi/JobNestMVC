using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobNestMVC.Controllers
{
    public class JobViewController : Controller
    {
        JOBNESTMVCEntities jmv = new JOBNESTMVCEntities();
        // GET: JobViewC
        public ActionResult JobsView_PageLoad()
        {
            var data = jmv.sp_ViewAllJobsPost().ToList();
            ViewBag.userdetails = data;
            return View();
        }

        public ActionResult searchjobclick(string JobTitle,
                                           string Location,
                                           string Experience,
                                           string Company)
        {
            var data = jmv.sp_ViewAllJobsPost().ToList();

            if (!string.IsNullOrWhiteSpace(JobTitle))
            {
                data = data.Where(x =>
                    x.job_title != null &&
                    x.job_title.ToLower().Contains(JobTitle.ToLower())
                ).ToList();
            }

            if (!string.IsNullOrWhiteSpace(Location))
            {
                data = data.Where(x =>
                    x.location != null &&
                    x.location.ToLower().Contains(Location.ToLower())
                ).ToList();
            }

            if (!string.IsNullOrWhiteSpace(Experience))
            {
                data = data.Where(x =>
                    x.experience.ToString().Contains(Experience)
                ).ToList();
            }

            if (!string.IsNullOrWhiteSpace(Company))
            {
                data = data.Where(x =>
                    x.Company != null &&
                    x.Company.ToLower().Contains(Company.ToLower())
                ).ToList();
            }

            ViewBag.userdetails = data;

            return View("JobsView_PageLoad");
        }

    }
}