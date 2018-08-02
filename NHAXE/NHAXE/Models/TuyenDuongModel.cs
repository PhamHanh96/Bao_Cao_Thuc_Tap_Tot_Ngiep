using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TuyenDuongModel
    {
        private DATVEDbContext context = null;

        public TuyenDuongModel()
        {
            context = new DATVEDbContext();
        }
        public List<TUYEN_DUONG> listAll()
        {
            var list = context.Database.SqlQuery<TUYEN_DUONG>("SP_TuyenDuong_ListAll").ToList();
            return list;
        }
        
    }
}
