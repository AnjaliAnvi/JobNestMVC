using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobNestMVC.Models;

namespace JobNestMVC.Controllers
{
    public class MyApplicationController : Controller
    {
        JOBNESTMVCEntities jmv = new JOBNESTMVCEntities();

        public ActionResult MyApplications_PageLoad()
        {
            if (Session["uid"] == null)
            {
                return RedirectToAction("Login_PageLoad", "LoginDB");
            }

            int uid = Convert.ToInt32(Session["uid"]);

            var data = jmv.Database.SqlQuery<MyApplication>(
                "EXEC SP_ViewMyApplications @user_id",
                new System.Data.SqlClient.SqlParameter("@user_id", uid)
            ).ToList();

            return View(data);
        }
    }
}
    