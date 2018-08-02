using Models.Framework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class DON_HANG_DAO
    {
        private DATVEDbContext context = new DATVEDbContext();
        public List<DON_HANG> listHD(string Email)
        {
            object[] sqlParams =
            {
                new SqlParameter ("@Email" ,Email),
            };
            var listHD = context.Database.SqlQuery<DON_HANG>("SP_HoaDon_List @Email", sqlParams).ToList();
            return listHD;
        }
        public List<DON_HANG> listAll()
        {
            return context.DON_HANG.ToList();
        }
        public DON_HANG TimMaDH(int mahd)
        {
            return context.DON_HANG.Find(mahd);
        }


        public bool UpdateDonHang(DON_HANG model)
        {

            try
            {
                var dh = context.DON_HANG.Find(model.MA_DH);
                dh.MA_LT = model.MA_LT;
                dh.EMAIL_DH = model.EMAIL_DH;
                dh.SOLUONGVE = model.SOLUONGVE;
                dh.TONG = model.TONG;
                dh.TRANG_THAI = model.TRANG_THAI;
                dh.EMAIL_NV = model.EMAIL_NV;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool Xoa(int MaDH)
        {
            try
            {
                var Kh = context.DON_HANG.Find(MaDH);
                context.DON_HANG.Remove(Kh);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
