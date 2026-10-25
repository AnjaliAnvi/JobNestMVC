using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobNestMVC.Models;

namespace JobNestMVC.Controllers
{
    public class CompanyProfileController : Controller
    {
        JOBNESTMVCEntities jmv = new JOBNESTMVCEntities();
        // GET: CompanyProfile
        public ActionResult CompanyProfile_PageLoad()
        {
            var getdata = jmv.sp_CompanyView(Convert.ToInt32(Session["uid"])).FirstOrDefault();
            return View(new CompanyProfeil
            {
                name=getdata.company_name,
                email=getdata.email,
                phone=getdata.phone,
                location=getdata.location,
                description=getdata.description,
                logo=getdata.logo
            });
        }
    }
}