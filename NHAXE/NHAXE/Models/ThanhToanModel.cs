using Models.DAO;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ThanhToanModel
    {
        private DATVEDbContext context = null;
        public ThanhToanModel()
        {
            context = new DATVEDbContext();
        }
        public THONGTINTHANHTOAN ThongTin(int madh)
        {
            THONGTINTHANHTOAN t = new THONGTINTHANHTOAN();
            t.DonHang = context.DON_HANG.Find(madh);
            t.LT = context.LO_TRINH.Find(t.DonHang.MA_LT);
            t.TD = context.TUYEN_DUONG.Find(t.LT.MS_TUYEN);
            t.KhachHang = context.KHACH_HANG.Find(t.DonHang.EMAIL_DH);
            return t;
        }
        public bool UpdateThanhToan(THONGTINTHANHTOAN t)
        {
            int ngay = DateTime.Now.Day;
            int thang = DateTime.Now.Month;
            int nam = DateTime.Now.Year;
            string today = nam + "-" + thang + "-" + ngay;
            t.DonHang.TRANG_THAI = 1;
            int soghe = t.LT.GHE_TRONG - t.DonHang.SOLUONGVE;
            t.LT.GHE_TRONG = soghe;
            var lt = new LO_TRINH_DAO();
            bool l = lt.UpdateLoTrinh(t.LT);
            var hd = new DON_HANG_DAO();
            bool h = hd.UpdateDonHang(t.DonHang);
            THANH_TOAN Thanhtoan = new THANH_TOAN();
            Thanhtoan.MA_DH = t.DonHang.MA_DH;
            Thanhtoan.NGAYMUA = DateTime.Parse(today);
            Thanhtoan.EMAIL = t.KhachHang.EMAIL_KH;
            var TT = new THANH_TOAN_DAO();
            int ma = TT.AddThanhToan(Thanhtoan);
            if (ma == 0 || l == false || h == false)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}
