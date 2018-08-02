using Models.Framework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{

    public class THANH_TOAN_DAO
    {
        private DATVEDbContext context = new DATVEDbContext();
        public List<THANH_TOAN> listAll()
        {
            return context.THANH_TOAN.ToList();
        }
        public int AddThanhToan(THANH_TOAN model)
        {
            context.THANH_TOAN.Add(model);
            context.SaveChanges();
            return model.MA_TT;
        }
    }
}
