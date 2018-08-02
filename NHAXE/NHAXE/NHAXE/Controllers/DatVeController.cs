using Models;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NHAXE.Controllers
{
    public class DatVeController : Controller
    {
        // GET: DatVe
        public ActionResult Index()
        {
            return View();
        }
         [HttpGet]
        public ActionResult Datve(int maLT)
        {

            if (Session["User"] != null)
                ViewBag.User = Session["User"].ToString();
            if (Session["Email"] != null)
                ViewBag.Email = Session["Email"].ToString();
            var ipldatve = new DatVeModel();
            var model = ipldatve.ThongTin(maLT);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Datve(THONGTINDATVE THDV)

        {
            var ipldatve = new DatVeModel();
            var model1 = ipldatve.ThongTin(THDV.LT[0].MA_LT);
            if (THDV.soluong == 0)
            {
                ModelState.AddModelError("", "Bạn chưa điền vào số lượng vé"); }
            else {
              
                model1.soluong = THDV.soluong;
                model1.tongtien = THDV.soluong * model1.TD[0].GIAVE;
                if (ModelState.IsValid)
                {

                    if (Session["User"] != null)
                        ViewBag.User = Session["User"].ToString();
                    if (Session["Email"] != null)
                        ViewBag.Email = Session["Email"].ToString();
                    string email = ViewBag.Email;
                    if (ViewBag.Email == null)
                    {
                        ModelState.AddModelError("", "Bạn chưa đăng nhập");
                        // return RedirectToAction("Index", "Login");
                    }
                    else
                    {

                        var model = new DatVeModel();
                      
                            int res = model.ThemMoi(email, model1.LT[0].MA_LT, model1.soluong, model1.tongtien);
                            if (res > 0)
                                ModelState.AddModelError("", "Them Don hang thanh cong");
                            else
                            {
                                ModelState.AddModelError("", "Không thêm được dữ liệu");
                            }
                       
                    }
                }
            }
            
            return View(model1);
        }
    }
        
   
}