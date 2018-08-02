using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NHAXE.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if(Session["User"] != null)
            ViewBag.User = Session["User"].ToString();
            if (Session["Email"] != null)
                ViewBag.Email = Session["Email"].ToString();
            return View();
        }
        public ActionResult Datve()
        {
            if (Session["User"] != null)
                ViewBag.User = Session["User"].ToString();
            if (Session["Email"] != null)
                ViewBag.Email = Session["Email"].ToString();
            return View();
        }
        public ActionResult Login()
           {
            if (Session["User"] != null)
                ViewBag.User = Session["User"].ToString();
            if (Session["Email"] != null)
                ViewBag.Email = Session["Email"].ToString();
            return View();
            }
        public ActionResult Create()
        {
            if (Session["User"] != null)
                ViewBag.User = Session["User"].ToString();
            if (Session["Email"] != null)
                ViewBag.Email = Session["Email"].ToString();
            return View();
        }
        public ActionResult Lienhe()
        {
            if (Session["User"] != null)
                ViewBag.User = Session["User"].ToString();
            if (Session["Email"] != null)
                ViewBag.Email = Session["Email"].ToString();
            return View();
        }
        public ActionResult Lichtrinh()
        {
            if (Session["User"] != null)
                ViewBag.User = Session["User"].ToString();
            if (Session["Email"] != null)
                ViewBag.Email = Session["Email"].ToString();
            return View();
        }
        public ActionResult ThanhToan()
        {
            if (Session["User"] != null)
                ViewBag.User = Session["User"].ToString();
            if (Session["Email"] != null)
                ViewBag.Email = Session["Email"].ToString();
            return View();
        }
        public ActionResult SaiGon()
        {
            if (Session["User"] != null)
                ViewBag.User = Session["User"].ToString();
            if (Session["Email"] != null)
                ViewBag.Email = Session["Email"].ToString();
            var iplTDuong = new TuyenDuongModel();
            var model = iplTDuong.listAll();
            return View(model);
            
        }
        public ActionResult DaLat()
        {
            if (Session["User"] != null)
                ViewBag.User = Session["User"].ToString();
            if (Session["Email"] != null)
                ViewBag.Email = Session["Email"].ToString();
            var iplTDuong = new TuyenDuongModel();
            var model = iplTDuong.listAll();
            return View(model);

        }
        public ActionResult NhaTrang()
        {
            if (Session["User"] != null)
                ViewBag.User = Session["User"].ToString();
            if (Session["Email"] != null)
                ViewBag.Email = Session["Email"].ToString();
            var iplTDuong = new TuyenDuongModel();
            var model = iplTDuong.listAll();
            return View(model);

        }
        public ActionResult ThongTinKhachHang()
        {
            if (Session["User"] != null)
                ViewBag.User = Session["User"].ToString();
            if (Session["Email"] != null)
                ViewBag.Email = Session["Email"].ToString();
            var iplTDuong = new KhachHangModel();
            var model = iplTDuong.InFO(ViewBag.Email);
            return View(model);

        }
        public ActionResult HDDV()
        {
            if (Session["User"] != null)
                ViewBag.User = Session["User"].ToString();
            if (Session["Email"] != null)
                ViewBag.Email = Session["Email"].ToString();
            return View();
        }
    }
}