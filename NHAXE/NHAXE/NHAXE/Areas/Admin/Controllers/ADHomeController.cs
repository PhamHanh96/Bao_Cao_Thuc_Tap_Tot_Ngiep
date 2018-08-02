using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NHAXE.Areas.Admin.Controllers
{
    public class ADHomeController : BaseController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            if (Session["Ten_NV"] != null)
                ViewBag.Ten_NV = Session["Ten_NV"].ToString();
            if (Session["CHUCVU_NV"] != null)
                ViewBag.CHUCVU_NV = Session["CHUCVU_NV"].ToString();
            if (Session["Email_NV"] != null)
                ViewBag.Email_NV = Session["Email_NV"].ToString();
            return View();
        }
    }
}