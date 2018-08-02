using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Models.Framework;
namespace Models
{
    public class AccoutnModel {
        private DATVEDbContext context = null;
       
        public AccoutnModel()
        {
            context = new DATVEDbContext();
        }

        //public String Login(string UserName,string Password)
        //{
        //    object[] sqlParams = 
        //    {
        //        new SqlParameter ("@UserName" ,UserName),
        //         new SqlParameter ("@Password",Password),
        //    };
        //    var res = context.Database.SqlQuery<String>("SP_Login_Account @UserName , @Password ", sqlParams).SingleOrDefault();
        //    return res;
        //}
        //public String LoginToEmail(string UserName, string Password)
        //{
        //    object[] sqlParams =
        //    {
        //        new SqlParameter ("@UserName" ,UserName),
        //         new SqlParameter ("@Password",Password),
        //    };
        //    var resToEmail = context.Database.SqlQuery<String>("SP_LoginToEmail @UserName , @Password ", sqlParams).SingleOrDefault();
        //    return resToEmail;
        //}
        public KHACH_HANG GetByEmail(string Email)
        {
            return context.KHACH_HANG.SingleOrDefault(x => x.EMAIL_KH == Email);
        }

        public int Login(string Email, string passWord)
        {
            var result = context.KHACH_HANG.SingleOrDefault(x => x.EMAIL_KH == Email);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.MATKHAU == passWord)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
        }
    }
}
