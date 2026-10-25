using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobNestMVC.Models;

namespace JobNestMVC.Controllers
{
    public class InsertCompanyController : Controller
    {
        JOBNESTMVCEntities dbobj = new JOBNESTMVCEntities();
        // GET: InsertCompany
        public ActionResult InsertCompany_PageLoad()
        {
            return View();
        }
        public ActionResult InsertCompany_Click(AdminInsert clsobj, HttpPostedFileBase file)
        {
            
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    string fname = Path.GetFileName(file.FileName);
                    var s = Server.MapPath("~/logo");
                    string pa = Path.Combine(s, fname);

                    file.SaveAs(pa);

                    var fullpath = Path.Combine("~\\logo", fname);
                    clsobj.logo = fullpath;
                }
                var getmaxid = dbobj.sp_MaxIdLogin().FirstOrDefault();
                int mid = Convert.ToInt32(getmaxid);
                int regid = 0;
                if (mid == 0)
                {
                    regid = 1;
                }
                else
                {
                    regid = mid + 1;
                }
                dbobj.sp_Company(regid, clsobj.name, clsobj.email, clsobj.phone, clsobj.location, clsobj.description, clsobj.logo);
                dbobj.sp_Login(regid, clsobj.username, clsobj.password, "company");
                clsobj.cmsg = "Successfully inserted";
                return View("InsertCompany_PageLoad", clsobj);
            }


            return View("InsertCompany_PageLoad", clsobj);
        }
}
}