using Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class LoTrinhModel
    {
        private DATVEDbContext context = null;
        public LoTrinhModel()
        {
            context = new DATVEDbContext();
        }
        public List<LO_TRINH> listMATUYEN(string matuyen)
        {
            object[] sqlParams =
            {
                new SqlParameter ("@Matuyen" ,matuyen),
            };
            var listLT = context.Database.SqlQuery<LO_TRINH>("SP_LoTrinh_List @Matuyen", sqlParams).ToList();
            return listLT;
        }
        public List<LO_TRINH> listAll()
        {
            var list = context.Database.SqlQuery<LO_TRINH>("SP_LoTrinh_ListAll").ToList();
            return list;
        }
    }
}
