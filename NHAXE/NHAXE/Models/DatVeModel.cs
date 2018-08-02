using Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class DatVeModel
    {
        private DATVEDbContext context = null;
        public DatVeModel()
        {
            context = new DATVEDbContext();
        }
        public THONGTINDATVE ThongTin(int malt)
        {
            THONGTINDATVE t = new THONGTINDATVE();

            object[] sqlParams =
            {
                new SqlParameter ("@MaLT" ,malt),
            };
            t.LT = context.Database.SqlQuery<LO_TRINH>("SP_LoTrinh_LT @MaLT", sqlParams).ToList();
            object[] sqlParams1 =
            {
                new SqlParameter ("@Matuyen" ,t.LT[0].MS_TUYEN),
            };
            t.TD = context.Database.SqlQuery<TUYEN_DUONG>("SP_TuyenDuong_MT @Matuyen", sqlParams1).ToList();
            return t;
        }
        public bool KiemTra(string email, int malt)
        {
            var hoadon = context.DON_HANG.ToList();
            foreach (var i in hoadon)
            {
                if (i.EMAIL_DH == email && i.MA_LT == malt)
                {
                    return false;
                }
                
            }
            return true;
        }
        public int ThemMoi( string email, int maLT, int Sluong, int tong)
        {
            int trangthai = -1;
            object[] sqlParams =
           {
                
                 new SqlParameter ("@EMAIL_KH",email),
                 new SqlParameter ("@MaLT" ,maLT),
                 new SqlParameter ("@Sluong",Sluong),
                  new SqlParameter ("@tong",tong),
                 new SqlParameter ("@trangthai",trangthai)
            };
            var res = context.Database.ExecuteSqlCommand("SP_Insert_DH @EMAIL_KH, @MaLT ,@Sluong, @tong,@trangthai", sqlParams);
            
            return res;

        }
    }
}
