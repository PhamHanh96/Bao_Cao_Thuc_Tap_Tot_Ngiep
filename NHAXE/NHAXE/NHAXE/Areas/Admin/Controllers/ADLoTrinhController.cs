using Models.DAO;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NHAXE.Areas.Admin.Controllers
{
    public class ADLoTrinhController : BaseController
    {
        // GET: Admin/ADLoTrinh
        public ActionResult Index()
        {
            if (Session["Ten_NV"] != null)
                ViewBag.Ten_NV = Session["Ten_NV"].ToString();
            if (Session["CHUCVU_NV"] != null)
                ViewBag.CHUCVU_NV = Session["CHUCVU_NV"].ToString();
            if (Session["Email_NV"] != null)
                ViewBag.Email_NV = Session["Email_NV"].ToString();
            var dao = new LO_TRINH_DAO();
            var list = dao.list();
            return View(list);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LO_TRINH model)
        {
            var dao1 = new XE_KHACH_DAO();
            model.GHE_TRONG = dao1.Tim(model.BSXE).SOCHO;
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
                    var dao = new LO_TRINH_DAO();
                    if (dao.kiemtra(model))
                    {
                        ModelState.AddModelError("", "Lộ trình đã tồn tại");
                    }
                    else
                    {
                        int ma = dao.AddLoTrinh(model);
                        if (ma != 0)
                        {
                            ModelState.AddModelError("", "Thêm thành công lộ trình");
                            // return RedirectToAction("Index", "ADTuyenDuong");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Thêm thất bại lộ trình");
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Bạn không có quyền admin");
                }
            }
            setViewBag();
            return View(model);
        }
        [HttpGet]
        public ActionResult Edit(int MaLT)
        {
            if (Session["Ten_NV"] != null)
                ViewBag.Ten_NV = Session["Ten_NV"].ToString();
            if (Session["CHUCVU_NV"] != null)
                ViewBag.CHUCVU_NV = Session["CHUCVU_NV"].ToString();
            if (Session["Email_NV"] != null)
                ViewBag.Email_NV = Session["Email_NV"].ToString();
            var td = new LO_TRINH_DAO();
           LO_TRINH mode = td.TimMaLT(MaLT);
            setViewBag();
            return View(mode);
        }
        public ActionResult Edit(LO_TRINH model)
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

                    var dao = new LO_TRINH_DAO();
                    if (dao.kiemtra(model))
                    {
                        ModelState.AddModelError("", "Lộ trình đã tồn tại");
                    }
                    else
                    {
                        bool kq = dao.UpdateLoTrinh(model);
                        if (kq)
                        {
                            ModelState.AddModelError("", "cập nhật thành công lộ trình");
                            //return RedirectToAction("Index", "ADTuyenDuong");
                        }
                        else
                        {
                            ModelState.AddModelError("", "cập nhật thất bại lộ trình");
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Bạn không có quyền admin");
                }
            }
            setViewBag();
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
            setViewBag();
            return View();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var result = new LO_TRINH_DAO().Xoa(id);
            if (result)
            {
                return Json(new { success = 1 });
            }
            return Json(new { success = 0 });
        }
       
        public void setViewBag(long ? selectedID = null)
        {
            var dao = new TUYEN_DUONG_DAO();
            var dao1 = new XE_KHACH_DAO();
            ViewBag.MS_TUYEN = new SelectList(dao.list(), "MS_TUYEN", "MS_TUYEN", selectedID);
            ViewBag.BSXE = new SelectList(dao1.list(), "MA_BSX", "MA_BSX", selectedID);
        }
    }
}