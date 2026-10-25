using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobNestMVC.Models;

namespace JobNestMVC.Controllers
{
    public class InsertUserController : Controller
    {
        JOBNESTMVCEntities jmv = new JOBNESTMVCEntities();
        // GET: InsertUser
        public ActionResult UserInsert_PageLoad()
        {
            InsertClass user = new InsertClass();
            user.Myfavqual = getqual();

            return View(user);
        }
        public List<checkBoxHelper> getqual()
        {
            List<checkBoxHelper> sts = new List<checkBoxHelper>()
            {
                new checkBoxHelper{value="UG", text="UG", valuecheck=true},
                new checkBoxHelper{value="PG", text="PG", valuecheck=false},
                new checkBoxHelper{value="DIPLOMA", text="DIPLOMA", valuecheck=false}
            };
            return sts;
        }
        public ActionResult UserInsert_Click(InsertClass clsobj, HttpPostedFileBase file, HttpPostedFileBase resumes, FormCollection form)
        {
            clsobj.Myfavqual = getqual();
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    string fname = Path.GetFileName(file.FileName);
                    var s = Server.MapPath("~/phs");
                    string pa = Path.Combine(s, fname);

                    file.SaveAs(pa);
                    
                    var fullpath = Path.Combine("~\\phs", fname);
                    clsobj.photo = fullpath;
                }
                if (resumes != null && resumes.ContentLength > 0)
                {
                    string fname = Path.GetFileName(resumes.FileName);
                    var m = Server.MapPath("~/resume");
                    string pa = Path.Combine(m, fname);

                    resumes.SaveAs(pa);
                    
                    var fullpath = Path.Combine("~\\resume", fname);
                    clsobj.resume = fullpath;
                }
                //var quid = string.Join(",", clsobj.selectedqul);
                //clsobj.qualification = quid;
                //clsobj.Myfavqual = getqual();

                //var getmaxid = jmv.sp_MaxIdLogin().FirstOrDefault();
                var quid = "";

                if (clsobj.selectedqul != null)
                {
                    quid = string.Join(",", clsobj.selectedqul);
                }

                clsobj.qualification = quid;
                clsobj.Myfavqual = getqual();

                var getmaxid = jmv.sp_MaxIdLogin().FirstOrDefault();

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
                jmv.sp_UserReg(regid, clsobj.name, clsobj.email, clsobj.phone, clsobj.location, clsobj.qualification, clsobj.experience, clsobj.resume, clsobj.photo);
                jmv.sp_Login(regid, clsobj.username, clsobj.pass, "user");
                clsobj.usermsg = "Successfully inserted";
                return View("UserInsert_PageLoad", clsobj);
            }            
            return View("UserInsert_PageLoad", clsobj);
        }

    }
}