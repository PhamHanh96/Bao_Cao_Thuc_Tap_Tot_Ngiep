using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
namespace Models.DAO
{
    public class NHAN_VIEN_DAO
    {
        private DATVEDbContext context = new DATVEDbContext();

        public List<NHAN_VIEN> listAll()
        {
            return context.NHAN_VIEN.OrderBy(x => x.MA_NV).ToList();
        }
        public NHAN_VIEN GetByEmail(string Email)
        {
            return context.NHAN_VIEN.SingleOrDefault(x=> x.EMAIL_NV==Email);
        }
       
        public int Login(string Email, string passWord)
        {
            var result = context.NHAN_VIEN.SingleOrDefault(x => x.EMAIL_NV == Email);
            if(result == null)
            {
                return 0;
            }
            else
            {
                if(result.MATKHAU == passWord)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
        }

        public String AddNhanVien(NHAN_VIEN model)
        {
            context.NHAN_VIEN.Add(model);
            context.SaveChanges();
            return model.EMAIL_NV;
        }
        public NHAN_VIEN TimEmailNV(string mat)
        {
            return context.NHAN_VIEN.Find(mat);
        }
        public bool XoaNhanVien(string mat)
        {
            try
            {
                var td = context.NHAN_VIEN.Find(mat);
                context.NHAN_VIEN.Remove(td);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UpdateNhanVien(NHAN_VIEN model)
        {
            try
            {
                var td = context.NHAN_VIEN.Find(model.EMAIL_NV);
                td.CHUCVU = model.CHUCVU;
                td.TENNV = model.TENNV;
                td.MA_NV = model.MA_NV;
                td.SDT_NV = model.SDT_NV;
                td.CMND_NV = model.CMND_NV;
                td.DIACHI_NV = model.DIACHI_NV;
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
