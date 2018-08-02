using Models;
using Models.DAO;
using Models.Framework;
using NHAXE.Areas.Admin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NHAXE.Controllers
{
    public class KhachHangController : Controller
    {
        // GET: KhachHang
        public ActionResult Index()
        {

            return View();
        }

        // GET: KhachHang/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: KhachHang/Create
        public ActionResult Create()
        {
            return View();
        }
        

        // POST: KhachHang/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(KHACH_HANG KH)
        {
            try
            {
                KH.MATKHAU = Encryptor.MD5Hash(KH.MATKHAU);
                KH.CONFIRM_PASS = Encryptor.MD5Hash(KH.CONFIRM_PASS);
                if (ModelState.IsValid)
                {
                    var m = new KHACH_HANG_DAO().TimEmailKH(KH.EMAIL_KH);
                    if (m == null)
                    {
                        var model = new KHACH_HANG_DAO();
                    string res = model.AddKhachHang(KH);
                    if (res != null)
                            ModelState.AddModelError("", "Đăng kí thành công");
                        else
                    {
                        ModelState.AddModelError("", "Không thêm được dữ liệu");
                    }
                }
                    else
                    { ModelState.AddModelError("", "Email đã sử dụng"); }
                      }
                return View(KH);

            }
            catch
            {
                return View();
            }
        }


        [HttpGet]
        public ActionResult Edit()
        {
            if (Session["User"] != null)
                ViewBag.User = Session["User"].ToString();
            if (Session["Email"] != null)
                ViewBag.Email = Session["Email"].ToString();
            var td = new KHACH_HANG_DAO().TimEmailKH(ViewBag.Email);

            return View(td);
        }

        // POST: KhachHang/Edit/5
        [HttpPost]
        public ActionResult Edit(KHACH_HANG model)
        {
            if (Session["User"] != null)
                ViewBag.User = Session["User"].ToString();
            if (Session["Email"] != null)
                ViewBag.Email = Session["Email"].ToString();
            if (ModelState.IsValid)
            {
                model.MATKHAU = Encryptor.MD5Hash(model.MATKHAU);
                model.CONFIRM_PASS = Encryptor.MD5Hash(model.CONFIRM_PASS);
                var dao = new KHACH_HANG_DAO();
                bool kq = dao.UpdateKhachHang(model);
                if (kq)
                {
                    ModelState.AddModelError("", "cập nhật thành công khách hàng");
                    //return RedirectToAction("Index", "ADKhachHang");
                }
                else
                {
                    ModelState.AddModelError("", "cập nhật thất bại khách hàng");
                }
            }
            return View(model);
        }

        // GET: KhachHang/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: KhachHang/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
