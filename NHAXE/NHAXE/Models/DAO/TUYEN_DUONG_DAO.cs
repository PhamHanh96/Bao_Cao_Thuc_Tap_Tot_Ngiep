using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace Models.DAO
{
    public class TUYEN_DUONG_DAO
    {
        private DATVEDbContext context = new DATVEDbContext();

        public IEnumerable<TUYEN_DUONG> listAll(int page, int pageSize)
        {
            return context.TUYEN_DUONG.OrderByDescending(x => x.MS_TUYEN).ToPagedList(page, pageSize);
        }
        public List<TUYEN_DUONG> list()
        {
            return context.TUYEN_DUONG.ToList();
        }
        public String AddTuyenDuong(TUYEN_DUONG model)
        {
            context.TUYEN_DUONG.Add(model);
            context.SaveChanges();
            return model.MS_TUYEN;
        }
        public TUYEN_DUONG TimMaTuyen(string mat)
        {
            return context.TUYEN_DUONG.Find(mat);
        }
        public bool Xoa(string mat)
        {
            try
            {
                var td = context.TUYEN_DUONG.Find(mat);
                context.TUYEN_DUONG.Remove(td);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
       
        public bool UpdateTuyenDuong(TUYEN_DUONG model)
        {
            try {
                var td = context.TUYEN_DUONG.Find(model.MS_TUYEN);
                td.BENDI = model.BENDI;
                td.BENDEN = model.BENDEN;
                td.QUANGDUONG = model.QUANGDUONG;
                td.THOIGIAN = model.THOIGIAN;
                td.GIAVE = model.GIAVE;
                context.SaveChanges();
                return true;
            } catch(Exception ex)
            {
                return false;
            }
           
        }
    }
}
