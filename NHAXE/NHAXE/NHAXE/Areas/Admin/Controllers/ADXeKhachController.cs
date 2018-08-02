using Models.DAO;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NHAXE.Areas.Admin.Controllers
{
    public class ADXeKhachController : BaseController
    {
        // GET: Admin/ADXeKhach
        public ActionResult Index()
        {
            if (Session["Ten_NV"] != null)
                ViewBag.Ten_NV = Session["Ten_NV"].ToString();
            if (Session["CHUCVU_NV"] != null)
                ViewBag.CHUCVU_NV = Session["CHUCVU_NV"].ToString();
            if (Session["Email_NV"] != null)
                ViewBag.Email_NV = Session["Email_NV"].ToString();
            var dao = new XE_KHACH_DAO();
            var list = dao.list();
            return View(list);
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(XE_KHACH model)
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
                    var m = new XE_KHACH_DAO().Tim(model.MA_BSX);
                    if (m == null)
                    {
                        var dao = new XE_KHACH_DAO();
                        string ma = dao.AddXeKhach(model);
                        if (ma != null)
                        {
                            ModelState.AddModelError("", "Thêm thành công xe khách");
                            // return RedirectToAction("Index", "ADTuyenDuong");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Thêm thất bại xe kháchg");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Bảng s bị trùng");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Bạn không có quyền admin");
                }
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(string BSX)
        {
            if (Session["Ten_NV"] != null)
                ViewBag.Ten_NV = Session["Ten_NV"].ToString();
            if (Session["CHUCVU_NV"] != null)
                ViewBag.CHUCVU_NV = Session["CHUCVU_NV"].ToString();
            if (Session["Email_NV"] != null)
                ViewBag.Email_NV = Session["Email_NV"].ToString();
            var td = new XE_KHACH_DAO().Tim(BSX);

            return View(td);
        }
        public ActionResult Edit(XE_KHACH model)
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
                    var dao = new XE_KHACH_DAO();
                    bool kq = dao.UpdateXekhach(model);
                    if (kq)
                    {
                        ModelState.AddModelError("", "cập nhật thành công xe khách");
                        //return RedirectToAction("Index", "ADTuyenDuong");
                    }
                    else
                    {
                        ModelState.AddModelError("", "cập nhật thất bại xe khách");
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
            var xk = new XE_KHACH_DAO().Tim(id);
            if(xk.LO_TRINH.Count>0)
            {
                return Json(new { success = 0 });
            }
            else {
                var result = new XE_KHACH_DAO().Xoa(id);

                if (result)
                {
                    return Json(new { success = 1 });
                }
                return Json(new { success = 0 });
            }
           
        
        }
    }
}