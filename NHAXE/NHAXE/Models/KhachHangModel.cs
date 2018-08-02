using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Models.Framework;
namespace Models
{
    public class KhachHangModel
    {
        private DATVEDbContext context = null;

        public KhachHangModel()
        {
            context = new DATVEDbContext();
        }

        public int Create(string name, string email, string sdt, string cmnd, string diachi, string matkhau)
        {
            object[] sqlParams =
           {
                new SqlParameter ("@TEN_KH" ,name),
                 new SqlParameter ("@EMAIL_KH",email),
                 new SqlParameter ("@SDT_KH" ,sdt),
                 new SqlParameter ("@CMND_KH",cmnd),
                  new SqlParameter ("@DIACHI_KH",diachi),
                 new SqlParameter ("@MATKHAU",matkhau)
            };
            var res = context.Database.ExecuteSqlCommand("SP_Insert_KH @TEN_KH, @EMAIL_KH ,@SDT_KH, @CMND_KH,@DIACHI_KH, @MATKHAU", sqlParams);

            return res;

        }
        public KHACH_HANG Info(string userName, string passWord)
        {

            object[] sqlParams =
            {
                new SqlParameter ("@UserName" ,userName),
                 new SqlParameter ("@Password",passWord)
            };
            KHACH_HANG model = context.Database.SqlQuery<KHACH_HANG>("SP_ThongTin_KH @UserName, @Password", sqlParams).SingleOrDefault();
            return model;
        }
        public THONGTINKHACHHANG InFO(string email)
        {
            var tt = new THONGTINKHACHHANG();
            tt.KhachHang = context.KHACH_HANG.Find(email);
            object[] sqlParams =
            {
                new SqlParameter ("@Email" ,email),
            };
            tt.ThanhToan = context.Database.SqlQuery<THANH_TOAN>("SP_ThanhToan_List @Email", sqlParams).ToList();
            
            return tt;
        }
        public List<KHACH_HANG> listAll()
        {
            var list = context.Database.SqlQuery<KHACH_HANG>("SP_INFOKHACHHANG").ToList();
            return list;
        }
    }
}
