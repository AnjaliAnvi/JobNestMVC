using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobNestMVC.Models;

namespace JobNestMVC.Controllers
{
    public class CompanyApplicationController : Controller
    {
        JOBNESTMVCEntities jmv = new JOBNESTMVCEntities();

        public ActionResult ViewApplications_PageLoad()
        {
            string username = Session["uname"].ToString();

            var company = jmv.Database.SqlQuery<CompanyDetails>(
                "EXEC SP_GetCompanyByUsername @username",
                new System.Data.SqlClient.SqlParameter("@username", username)
            ).FirstOrDefault();

            if (company == null)
            {
                return Content("Company not found");
            }

            string companyName = company.company_name;

            var data = jmv.Database.SqlQuery<CompanyApplication>(
                "EXEC SP_ViewCompanyApplications @Company",
                new System.Data.SqlClient.SqlParameter("@Company", companyName)
            ).ToList();

            return View(data);
        }
        public ActionResult AcceptApplication(int id)
        {
            jmv.Database.ExecuteSqlCommand(
                "EXEC SP_UpdateApplicationStatus @application_id, @status",
                new System.Data.SqlClient.SqlParameter("@application_id", id),
                new System.Data.SqlClient.SqlParameter("@status", "Accepted")
            );

            return RedirectToAction("ViewApplications_PageLoad");
        }

        public ActionResult RejectApplication(int id)
        {
            jmv.Database.ExecuteSqlCommand(
                "EXEC SP_UpdateApplicationStatus @application_id, @status",
                new System.Data.SqlClient.SqlParameter("@application_id", id),
                new System.Data.SqlClient.SqlParameter("@status", "Rejected")
            );

            return RedirectToAction("ViewApplications_PageLoad");
        }
    }
}