using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobNestMVC.Models;

namespace JobNestMVC.Controllers
{
    public class UserProfileController : Controller
    {
        JOBNESTMVCEntities jmv = new JOBNESTMVCEntities();
        // GET: UserProfile
        public ActionResult UserProfile_PageLoad()
        {
            var getdata = jmv.sp_UserView(Convert.ToInt32(Session["uid"])).FirstOrDefault();
            return View(new UserProfile
            {
                name = getdata.name,
                email=getdata.email,
                phone=getdata.phone,
                location=getdata.location,
                experience=Convert.ToInt32(getdata.experience),
                qualification=getdata.qualification,
                resume=getdata.resume,
                photo=getdata.photo

            }) ;
        }

    }
}