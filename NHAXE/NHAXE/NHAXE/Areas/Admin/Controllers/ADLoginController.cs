using Models.DAO;
using NHAXE.Areas.Admin.Common;
using NHAXE.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NHAXE.Areas.Admin.Controllers
{
    public class ADLoginController : Controller
    {
        // GET: Admin/ADLogin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(ADLoginModel model)
        {
            if (ModelState.IsValid) {
                var dao = new NHAN_VIEN_DAO();
                var result = dao.Login(model.Email, Encryptor.MD5Hash(model.Password));
                if (result ==1)
                {
                    var user = dao.GetByEmail(model.Email);
                    var userSession = new UserLogin();
                    userSession.Email = user.EMAIL_NV;
                    Session["Email_NV"] = userSession.Email;
                    userSession.Userid = user.MA_NV;
                    userSession.TENNV = user.TENNV;
                    Session["Ten_NV"] = userSession.TENNV;
                    userSession.CHUCVU_NV = user.CHUCVU;
                    Session["CHUCVU_NV"] = userSession.CHUCVU_NV;
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                     return RedirectToAction("Index", "ADTuyenDuong");
                }else if (result == 0)
                {
                        ModelState.AddModelError("", "Tên Đăng nhập không tồn tại");
                }else if (result == -1)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng");
                }

            }
            return View("Index");

        }
        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }
    }
}