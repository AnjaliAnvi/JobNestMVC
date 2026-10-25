using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobNestMVC.Models;

namespace JobNestMVC.Controllers
{
    public class LoginDBController : Controller
    {
        JOBNESTMVCEntities dbobj = new JOBNESTMVCEntities();
        // GET: LoginDB
        public ActionResult Login_PageLoad()
        {
            return View();
        }
        public ActionResult UserHome()
        {
            return View();
        }
        public ActionResult CompanyHome()
        {
            return View();
        }
        public ActionResult Login_Click(LoginCls objcls)
        {
            if (ModelState.IsValid)
            {
                var val = dbobj.sp_CountLogId(objcls.Uname, objcls.password).First();
                if (val == 1)
                {
                    var uid = dbobj.sp_LogId(objcls.Uname, objcls.password).FirstOrDefault();
                    Session["uid"] = uid;
                    Session["uname"] = objcls.Uname;

                    var lt = dbobj.sp_LogType(objcls.Uname, objcls.password).FirstOrDefault();
                    if (lt == "user")
                    {
                        return RedirectToAction("UserHome");
                        //objcls.msg = "User Home";
                    }
                    else if (lt == "company")
                    {
                        return RedirectToAction("CompanyHome");
                        //objcls.msg = "Company Home";
                    }
                }
                else
                {
                    ModelState.Clear();
                    objcls.msg = "Invalid username and password.....";
                    return View("Login_PageLoad", objcls);
                }
            }
            else
            {
                ModelState.Clear();
                objcls.msg = "Invalid username and password.....";
                return View("Login_PageLoad", objcls);
            }
            return View("Login_PageLoad", objcls);
        }
    }
    }
