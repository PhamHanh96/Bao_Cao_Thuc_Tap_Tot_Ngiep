using Models.Framework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class XE_KHACH_DAO
    {
        private DATVEDbContext context = new DATVEDbContext();
        public List<XE_KHACH> list()
        {
            return context.XE_KHACH.ToList();
        }

        public IEnumerable<XE_KHACH> listAll(int page, int pageSize)
        {
            return context.XE_KHACH.OrderBy(x => x.MA_BSX).ToPagedList(page, pageSize);
        }
        public XE_KHACH Tim(string BSX)
        {
            
            return context.XE_KHACH.Find(BSX);
        }
        public String AddXeKhach(XE_KHACH model)
        {
            context.XE_KHACH.Add(model);
            context.SaveChanges();
            return model.MA_BSX;
        }
        public bool Xoa(string eMail)
        {
            try
            {
                var Kh = context.XE_KHACH.Find(eMail);
                context.XE_KHACH.Remove(Kh);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UpdateXekhach(XE_KHACH model)
        {
            try
            {
                var td = context.XE_KHACH.Find(model.MA_BSX);
                td.MA_BSX = model.MA_BSX;
                td.SOCHO = model.SOCHO;
                
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
