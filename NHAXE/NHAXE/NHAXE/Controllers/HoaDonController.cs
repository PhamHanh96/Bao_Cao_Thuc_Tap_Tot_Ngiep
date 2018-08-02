using Models;
using Models.DAO;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NHAXE.Controllers
{
    public class HoaDonController : Controller
    {
        // GET: HoaDon
        public ActionResult Index()
        {
            if (Session["User"] != null)
                ViewBag.User = Session["User"].ToString();
            if (Session["Email"] != null)
            {
                ViewBag.Email = Session["Email"].ToString();
                var hoadon = new DON_HANG_DAO();
                var model = hoadon.listHD(ViewBag.Email);
                return View(model);
            }
            return View();
        }
        public ActionResult ThanhToan(int madh)
        {
            if (Session["User"] != null)
                ViewBag.User = Session["User"].ToString();
            if (Session["Email"] != null)
            {
                ViewBag.Email = Session["Email"].ToString();
                var thanhtoan = new ThanhToanModel();
                var model = thanhtoan.ThongTin(madh);
                return View(model);
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThanhToan(THONGTINTHANHTOAN THTT)

        {
            if (Session["User"] != null)
                ViewBag.User = Session["User"].ToString();
            if (Session["Email"] != null)
                ViewBag.Email = Session["Email"].ToString();
            var thanhtoan = new ThanhToanModel();
            var model = thanhtoan.ThongTin(THTT.DonHang.MA_DH);
            
            if (ModelState.IsValid)
            {
                if (model.DonHang.TRANG_THAI == 1)
                {
                    ModelState.AddModelError("", "Đơn Hàng Đã Thanh Toán");
                }
                else if (model.DonHang.TRANG_THAI == -1)
                {
                    ModelState.AddModelError("", "Đơn Hàng Chưa Duyệt. Vui Lòng Đợi!");
                }
                else
                {
                    var ruttien = new ThanhToanOnline();
                    model.SoTaiKhoan = THTT.SoTaiKhoan;
                    if (ruttien.KiemTraTK(THTT.SoTaiKhoan) == 1)
                    {

                        int result = ruttien.listNH(model.SoTaiKhoan, model.DonHang.TONG);
                        if (result == 1)
                        {
                            var capnhat = new ThanhToanModel();
                            bool Kq = capnhat.UpdateThanhToan(model);
                            if (Kq)
                            {
                                ModelState.AddModelError("", "Thanh Toán Thành công");
                            }
                            else
                            {
                                ModelState.AddModelError("", "Xảy ra lỗi trong quá trình cập nhật thông tin");
                            }

                        }
                        else
                        {
                            ModelState.AddModelError("", "Thanh toán thất bại. Vui lòng kiểm tra số tiền trong tài khoản");
                        }
                    }else
                    {
                        ModelState.AddModelError("", "Tài khoản bạn nhập chưa tồn tại.");
                    }
                }
            }
            return View(model);
        }
        
    }
}