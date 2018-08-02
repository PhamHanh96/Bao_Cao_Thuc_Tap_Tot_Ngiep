using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
namespace Models.DAO
{
    public class KHACH_HANG_DAO
    {
        private DATVEDbContext context = new DATVEDbContext();

        public List <KHACH_HANG> listAll()
        {
            return context.KHACH_HANG.ToList();
        }
        public KHACH_HANG TimEmailKH(string mat)
        {
            return context.KHACH_HANG.Find(mat);
        }
        public String AddKhachHang(KHACH_HANG model)
        {
            context.KHACH_HANG.Add(model);
            context.SaveChanges();
            return model.EMAIL_KH;
        }
        
        public bool Xoa(string eMail)
        {
            try
            {
                var Kh = context.KHACH_HANG.Find(eMail);
                context.KHACH_HANG.Remove(Kh);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UpdateKhachHang(KHACH_HANG model)
        {
            try
            {
                var td = context.KHACH_HANG.Find(model.EMAIL_KH);
                td.TEN_KH = model.TEN_KH;
                td.SDT_KH = model.SDT_KH;
                td.CMND_KH = model.CMND_KH;
                td.DIACHI_KH = model.DIACHI_KH;
                td.MATKHAU = model.MATKHAU;
                td.CONFIRM_PASS = model.CONFIRM_PASS;
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
