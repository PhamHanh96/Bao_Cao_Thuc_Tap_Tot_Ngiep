using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NHAXE.Controllers
{
    public class LoTrinhController : Controller
    {
        // GET: LoTrinh
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetLoTrinh(string mT)
        {
            //maT = "DALAT-SAIGON";
            if (Session["User"] != null)
                ViewBag.User = Session["User"].ToString();
            var iplLtrinh = new LoTrinhModel();
            var model = iplLtrinh.listMATUYEN(mT);

            return View(model);
        }
    }
}