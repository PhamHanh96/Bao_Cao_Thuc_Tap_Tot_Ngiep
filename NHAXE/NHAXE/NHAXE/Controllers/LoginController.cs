using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using NHAXE.Models;
using NHAXE.Code;
using NHAXE.Areas.Admin.Common;

namespace NHAXE.Controllers
{
    public class LoginController : Controller
    {
        
        public object MessageBox { get;set; }

        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index (LoginModel model)
        {
            
           
            if ( ModelState.IsValid)
            {
                string mk = Encryptor.MD5Hash(model.MATKHAU);
                var result = new AccoutnModel().Login(model.EMAIL_KH, mk);
                var ressultEmail = new AccoutnModel().GetByEmail(model.EMAIL_KH);
                Session["Email"] = ressultEmail.EMAIL_KH;
                Session["User"] = ressultEmail.TEN_KH;
                if (result == 1)
                {
                    //SessionHelper.SetSession(new UserSession() { Name = model.TEN_KH});
                    return RedirectToAction("Index", "Home");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tên Đăng Nhập không tồn tại");
                }
                else
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng");
                }
            }
            
            return View(model);
        }
        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }
    }
}