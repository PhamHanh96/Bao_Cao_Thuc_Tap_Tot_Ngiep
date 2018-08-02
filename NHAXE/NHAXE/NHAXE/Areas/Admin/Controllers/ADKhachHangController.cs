using Models.DAO;
using Models.Framework;
using NHAXE.Areas.Admin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NHAXE.Areas.Admin.Controllers
{
    public class ADKhachHangController : BaseController
    {
        // GET: Admin/ADKhachHang
        public ActionResult Index()
        {
            if (Session["Ten_NV"] != null)
                ViewBag.Ten_NV = Session["Ten_NV"].ToString();
            if (Session["CHUCVU_NV"] != null)
                ViewBag.CHUCVU_NV = Session["CHUCVU_NV"].ToString();
            if (Session["Email_NV"] != null)
                ViewBag.Email_NV = Session["Email_NV"].ToString();
            var dao = new KHACH_HANG_DAO();
            var list = dao.listAll();
            return View(list);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(KHACH_HANG model)
        {

            if (ModelState.IsValid)
            {
                if (Session["Ten_NV"] != null)
                    ViewBag.Ten_NV = Session["Ten_NV"].ToString();
                if (Session["CHUCVU_NV"] != null)
                    ViewBag.CHUCVU_NV = Session["CHUCVU_NV"].ToString();
                if (Session["Email_NV"] != null)
                    ViewBag.Email_NV = Session["Email_NV"].ToString();
                if (ViewBag.CHUCVU_NV == "GIAMDOC")
                {
                    var m = new KHACH_HANG_DAO().TimEmailKH(model.EMAIL_KH);
                    if (m == null)
                    {
                        model.MATKHAU = Encryptor.MD5Hash(model.MATKHAU);
                        model.CONFIRM_PASS = Encryptor.MD5Hash(model.CONFIRM_PASS);
                        var dao = new KHACH_HANG_DAO();
                        string ma = dao.AddKhachHang(model);
                        if (ma != null)
                        {
                            ModelState.AddModelError("", "Thêm thành công khách hàng");
                            // return RedirectToAction("Index", "ADKhachHang");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Thêm thất bại khách hàng");
                        }
                    }
                    else
                    { ModelState.AddModelError("", "Email đã sử dụng"); }
                }
                else
                {
                    ModelState.AddModelError("", "Bạn không có quyền admin");
                }

            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            if (Session["Ten_NV"] != null)
                ViewBag.Ten_NV = Session["Ten_NV"].ToString();
            if (Session["CHUCVU_NV"] != null)
                ViewBag.CHUCVU_NV = Session["CHUCVU_NV"].ToString();
            if (Session["Email_NV"] != null)
                ViewBag.Email_NV = Session["Email_NV"].ToString();
            return View();
        }
        [HttpGet]
        public ActionResult Edit(string eMail)
        {
            if (Session["Ten_NV"] != null)
                ViewBag.Ten_NV = Session["Ten_NV"].ToString();
            if (Session["CHUCVU_NV"] != null)
                ViewBag.CHUCVU_NV = Session["CHUCVU_NV"].ToString();
            if (Session["Email_NV"] != null)
                ViewBag.Email_NV = Session["Email_NV"].ToString();
            var td = new KHACH_HANG_DAO().TimEmailKH(eMail);

            return View(td);
        }
        public ActionResult Edit(KHACH_HANG model)
        {
            if (ModelState.IsValid)
            {
                if (Session["Ten_NV"] != null)
                    ViewBag.Ten_NV = Session["Ten_NV"].ToString();
                if (Session["CHUCVU_NV"] != null)
                    ViewBag.CHUCVU_NV = Session["CHUCVU_NV"].ToString();
                if (Session["Email_NV"] != null)
                    ViewBag.Email_NV = Session["Email_NV"].ToString();
                if (ViewBag.CHUCVU_NV == "GIAMDOC")
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
                else
                {
                    ModelState.AddModelError("", "Bạn không có quyền admin");
                }
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(string id)
        {
            var kh = new KHACH_HANG_DAO().TimEmailKH(id);
            if (kh.DON_HANG.Count > 0)
            {
                return Json(new { success = 0 });
            }
            else {
                var result = new KHACH_HANG_DAO().Xoa(id);
                if (result)
                {
                    return Json(new { success = 1 });
                }
                return Json(new { success = 0 });
            }
            
        }
        
    }
}