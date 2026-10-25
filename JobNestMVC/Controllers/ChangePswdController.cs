using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobNestMVC.Models;

namespace JobNestMVC.Controllers
{
    public class ChangePswdController : Controller
    {
        JOBNESTMVCEntities jmv = new JOBNESTMVCEntities();
        // GET: ChangePswd
        public ActionResult ChangePswd_PageLoad()
        {
            return View();
            var getdata = jmv.sp_ChangePswd(Session["uname"].ToString()).FirstOrDefault();
            return View(new ChangePassword
            {
                oldpwd = getdata
            });
        }
        public ActionResult ChangePswd_Update(ChangePassword obj)
        {
           var getdata = jmv.sp_ChangePswd(Session["uname"].ToString()).FirstOrDefault();
            if (obj.oldpwd != getdata)
            {
                obj.msg = "Old password incorrect";
                return View("ChangePswd_PageLoad", obj);
            }
            if (obj.newpwd != obj.confirmpwd)
            {
                obj.msg = "New password and confirm password do not match";
                return View("ChangePswd_PageLoad", obj);
            }

            ObjectParameter op = new ObjectParameter("status", typeof(int));

            jmv.sp_changepaswd(Session["uname"].ToString(), getdata, obj.newpwd, op);

            int val = Convert.ToInt32(op.Value);

            if (val == 1)
            {
                obj.msg = "Password changed successfully";
            }
            else
            {
                obj.msg = "Password changed unsuccessfully";
            }

            return View("ChangePswd_PageLoad", obj);
        }
    }
}