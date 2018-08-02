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
    public class ADNhanVienController : BaseController
    {
        // GET: Admin/ADNhanVien
        public ActionResult Index()
        {
            if (Session["Ten_NV"] != null)
                ViewBag.Ten_NV = Session["Ten_NV"].ToString();
            if (Session["CHUCVU_NV"] != null)
                ViewBag.CHUCVU_NV = Session["CHUCVU_NV"].ToString();
            if (Session["Email_NV"] != null)
                ViewBag.Email_NV = Session["Email_NV"].ToString();
            var dao = new NHAN_VIEN_DAO();
            var list = dao.listAll();
            return View(list);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NHAN_VIEN model)
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
                    var m = new NHAN_VIEN_DAO().TimEmailNV(model.EMAIL_NV);
                    if (m == null)
                    {
                        var dao = new NHAN_VIEN_DAO();
                        string ma = dao.AddNhanVien(model);
                        if (ma != null)
                        {
                            ModelState.AddModelError("", "Thêm thành công nhân viên");
                            // return RedirectToAction("Index", "ADTuyenDuong");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Thêm thất bại nhân viên");
                        }
                    }
                    else
                    { ModelState.AddModelError("", "Email nhân viên bị trùng"); }
                }
                else {
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
            var td = new NHAN_VIEN_DAO().TimEmailNV(eMail);

            return View(td);
        }
        [HttpGet]
        public ActionResult XemThongTin()
        {
            if (Session["Ten_NV"] != null)
                ViewBag.Ten_NV = Session["Ten_NV"].ToString();
            if (Session["CHUCVU_NV"] != null)
                ViewBag.CHUCVU_NV = Session["CHUCVU_NV"].ToString();
            if (Session["Email_NV"] != null)
                ViewBag.Email_NV = Session["Email_NV"].ToString();
            var td = new NHAN_VIEN_DAO().TimEmailNV(ViewBag.Email_NV);

            return View(td);
        }
        public ActionResult XemThongTin(NHAN_VIEN model)
        {

            if (ModelState.IsValid)
            {
                if (Session["Ten_NV"] != null)
                    ViewBag.Ten_NV = Session["Ten_NV"].ToString();
                if (Session["CHUCVU_NV"] != null)
                    ViewBag.CHUCVU_NV = Session["CHUCVU_NV"].ToString();
                if (Session["Email_NV"] != null)
                    ViewBag.Email_NV = Session["Email_NV"].ToString();
               
                    var dao = new NHAN_VIEN_DAO();
                    model.MATKHAU = Encryptor.MD5Hash(model.MATKHAU);
                    model.CONFIRM_PASS = Encryptor.MD5Hash(model.CONFIRM_PASS);
                    bool kq = dao.UpdateNhanVien(model);
                    if (kq)
                    {
                        ModelState.AddModelError("", "Cập nhật thành công thông tin cá nhân");
                        //return RedirectToAction("Index", "ADTuyenDuong");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Cập nhật thất bại thông tin cá nhân");
                    }
                
                
            }
            return View(model);
        }
        public ActionResult Edit(NHAN_VIEN model)
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
                    var dao = new NHAN_VIEN_DAO();
                    model.MATKHAU = Encryptor.MD5Hash(model.MATKHAU);
                    model.CONFIRM_PASS = Encryptor.MD5Hash(model.CONFIRM_PASS);
                    bool kq = dao.UpdateNhanVien(model);
                    if (kq)
                    {
                        ModelState.AddModelError("", "Cập nhật thành công Nhân Viên");
                        //return RedirectToAction("Index", "ADTuyenDuong");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Cập nhật thất bại Nhân Viên");
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
            var kh = new NHAN_VIEN_DAO().TimEmailNV(id);
            if (kh.DON_HANG.Count > 0)
            {
                return Json(new { success = 0 });
            }
            else
            {
                var result = new NHAN_VIEN_DAO().XoaNhanVien(id);
                if (result)
                {
                    return Json(new { success = 1 });
                }
                return Json(new { success = 0 });
            }

        }

        public void SetViewBag(string eMail = null)
        {

        }
    }
}
