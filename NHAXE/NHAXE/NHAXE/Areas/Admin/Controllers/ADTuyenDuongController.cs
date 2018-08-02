using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Models.DAO;
using Models.Framework;

namespace NHAXE.Areas.Admin.Controllers
{
    public class ADTuyenDuongController : BaseController
    {
        // GET: Admin/ADTuyenDuong
        public ActionResult Index(int page = 1, int pageSize = 5)
        {
            if (Session["Ten_NV"] != null)
                ViewBag.Ten_NV = Session["Ten_NV"].ToString();
            if (Session["CHUCVU_NV"] != null)
                ViewBag.CHUCVU_NV = Session["CHUCVU_NV"].ToString();
            if (Session["Email_NV"] != null)
                ViewBag.Email_NV = Session["Email_NV"].ToString();
            var dao = new TUYEN_DUONG_DAO();
            var list = dao.list();
            return View(list);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TUYEN_DUONG model)
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
                    var m = new TUYEN_DUONG_DAO().TimMaTuyen(model.MS_TUYEN);
                    if (m == null)
                    {
                        var dao = new TUYEN_DUONG_DAO();
                        string ma = dao.AddTuyenDuong(model);
                        if (ma != null)
                        {
                            ModelState.AddModelError("", "Thêm thành công tuyến đường");
                            // return RedirectToAction("Index", "ADTuyenDuong");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Thêm thất bại tuyến đường");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Mã tuyến bị trùng"); }
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
        public ActionResult Edit(string maTuyen)
        {
            if (Session["Ten_NV"] != null)
                ViewBag.Ten_NV = Session["Ten_NV"].ToString();
            if (Session["CHUCVU_NV"] != null)
                ViewBag.CHUCVU_NV = Session["CHUCVU_NV"].ToString();
            if (Session["Email_NV"] != null)
                ViewBag.Email_NV = Session["Email_NV"].ToString();
            var td = new TUYEN_DUONG_DAO().TimMaTuyen(maTuyen);

            return View(td);
        }
        public ActionResult Edit(TUYEN_DUONG model)
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
                    var dao = new TUYEN_DUONG_DAO();
                    bool kq = dao.UpdateTuyenDuong(model);
                    if (kq)
                    {
                        ModelState.AddModelError("", "cập nhật thành công tuyến đường");
                        //return RedirectToAction("Index", "ADTuyenDuong");
                    }
                    else
                    {
                        ModelState.AddModelError("", "cập nhật thất bại tuyến đường");
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
        public async Task<ActionResult> Delete(string id)
        {
            var result = new TUYEN_DUONG_DAO().Xoa(id);
            if (result)
            {
                return Json(new { success = 1 });
            }
            return Json(new { success = 0 });
        }
        public void SetViewBag(string maTuyen = null)
        {

        }
    }
}