using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using JobNestMVC.Models;

namespace JobNestMVC.Controllers
{
    public class JobDescriptionController : Controller
    {
        JOBNESTMVCEntities jmv = new JOBNESTMVCEntities();
        // GET: JobDescription
        public ActionResult JobDescription_PageLoad(int id)
        {
            var job = jmv.Database.SqlQuery<JobDetails>(
                "EXEC SP_GetJobDetails @job_id",
                new System.Data.SqlClient.SqlParameter("@job_id", id)
            ).FirstOrDefault();

            if (job == null)
            {
                return HttpNotFound();
            }

            ViewBag.Applied = false;

            if (Session["uid"] != null)
            {
                int uid = Convert.ToInt32(Session["uid"]);

                int count = jmv.Database.SqlQuery<int>(
                    "EXEC SP_CheckJobApplied @job_id, @user_id",
                    new System.Data.SqlClient.SqlParameter("@job_id", id),
                    new System.Data.SqlClient.SqlParameter("@user_id", uid)
                ).FirstOrDefault();

                if (count > 0)
                {
                    ViewBag.Applied = true;
                }
            }

            return View(job);
        }
        public ActionResult ApplyJob_PageLoad(int id)
        {
            ViewBag.JobId = id;

            return View();
        }

        [HttpPost]
        public ActionResult ApplyJob(
     JobApplication obj,
     HttpPostedFileBase resumeFile)
        {
            if (Session["uid"] == null)
            {
                return RedirectToAction("Login_PageLoad", "Login");
            }

            int uid = Convert.ToInt32(Session["uid"]);

            string resume = "";

            if (resumeFile != null && resumeFile.ContentLength > 0)
            {
                string filename = System.IO.Path.GetFileName(resumeFile.FileName);

                string path = Server.MapPath("~/resume/");

                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                }

                string fullpath = System.IO.Path.Combine(path, filename);

                resumeFile.SaveAs(fullpath);

                resume = "~/resume/" + filename;
            }

            string result = jmv.Database.SqlQuery<string>(
                "EXEC SP_ApplyJob @job_id, @user_id, @name, @experience, @location, @skills, @resume",
                new System.Data.SqlClient.SqlParameter("@job_id", obj.job_id),
                new System.Data.SqlClient.SqlParameter("@user_id", uid),
                new System.Data.SqlClient.SqlParameter("@name", obj.name),
                new System.Data.SqlClient.SqlParameter("@experience", obj.experience),
                new System.Data.SqlClient.SqlParameter("@location", obj.location),
                new System.Data.SqlClient.SqlParameter("@skills", obj.skills),
                new System.Data.SqlClient.SqlParameter("@resume", resume)
            ).FirstOrDefault();

            if (result == "Already Applied")
            {
                TempData["Message"] = "You are already applied for this job.";
            }
            else
            {
                TempData["Message"] = "Application submitted successfully.";
            }

            return RedirectToAction(
                "JobDescription_PageLoad",
                new { id = obj.job_id }
            );
        }
    }
}