using Models.Framework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class LO_TRINH_DAO
    {
        private DATVEDbContext context = new DATVEDbContext();

        public IEnumerable<LO_TRINH> listAll(int page, int pageSize)
        {
            return context.LO_TRINH.OrderBy(x => x.MA_LT).ToPagedList(page, pageSize);
        }
        public int AddLoTrinh(LO_TRINH model)
        {
            context.LO_TRINH.Add(model);
            context.SaveChanges();
            return model.MA_LT;
        }
        public List<LO_TRINH> list()
        {
            return context.LO_TRINH.ToList();
        }
        public bool kiemtra(LO_TRINH model)
        {
            var lt = new LO_TRINH_DAO();
            List<LO_TRINH> ltr = lt.list();
            foreach (LO_TRINH a in ltr)
            {
                if (a.MS_TUYEN == model.MS_TUYEN && a.NGAYDI == model.NGAYDI && a.GIO == model.GIO && a.BSXE == model.BSXE)
                { return true; }
            }
            return false;
        }
        public LO_TRINH TimMaLT(int maLT)
        {
            return context.LO_TRINH.Find(maLT);
        }
        public bool UpdateLoTrinh(LO_TRINH model)
        {
            
            try
            {
                var td = context.LO_TRINH.Find(model.MA_LT);
                td.MS_TUYEN = model.MS_TUYEN;
                td.BSXE = model.BSXE;
                td.NGAYDI = model.NGAYDI;
                td.GIO = model.GIO;
                td.GHE_TRONG = model.GHE_TRONG;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool Xoa(int malt)
        {
            try
            {
                var td = context.LO_TRINH.Find(malt);
                context.LO_TRINH.Remove(td);
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
