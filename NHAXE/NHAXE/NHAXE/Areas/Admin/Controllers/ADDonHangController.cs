using Models.DAO;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NHAXE.Areas.Admin.Controllers
{
    public class ADDonHangController : BaseController
    {
        // GET: Admin/ADDonHang
        public ActionResult Index()
        {
            if (Session["Ten_NV"] != null)
                ViewBag.Ten_NV = Session["Ten_NV"].ToString();
            if (Session["CHUCVU_NV"] != null)
                ViewBag.CHUCVU_NV = Session["CHUCVU_NV"].ToString();
            if (Session["Email_NV"] != null)
                ViewBag.Email_NV = Session["Email_NV"].ToString();
            var dao = new DON_HANG_DAO();
            var list = dao.listAll();
            return View(list);
        }
        [HttpGet]
        public ActionResult Edit(int MaDH)
        {
            var td = new DON_HANG_DAO();
            DON_HANG mode = td.TimMaDH(MaDH);

            return View(mode);
        }
        public ActionResult Edit(DON_HANG model)
        {
            if (ModelState.IsValid)
            {

                var dao = new DON_HANG_DAO();
                bool kq = dao.UpdateDonHang(model);
                if (kq)
                {
                    ModelState.AddModelError("", "cập nhật thành công hóa đơn");
                    //return RedirectToAction("Index", "ADTuyenDuong");
                }
                else
                {
                    ModelState.AddModelError("", "cập nhật thất bại hóa đơn");
                }

            }

            return View(model);
        }
        [HttpPost]
        public ActionResult Duyet(int id)
        {
            if (Session["Ten_NV"] != null)
                ViewBag.Ten_NV = Session["Ten_NV"].ToString();
            if (Session["CHUCVU_NV"] != null)
                ViewBag.CHUCVU_NV = Session["CHUCVU_NV"].ToString();
            if (Session["Email_NV"] != null)
                ViewBag.Email_NV = Session["Email_NV"].ToString();
            var dao = new DON_HANG_DAO();
            var model = dao.TimMaDH(id);
            
            if (model.TRANG_THAI==-1)
            {
                model.EMAIL_NV = @ViewBag.Email_NV;
                model.TRANG_THAI = 0;
                new DON_HANG_DAO().UpdateDonHang(model);
                return Json(new { success = 1 });
            }
            return Json(new { success = 0 });
            
        }
    }
}