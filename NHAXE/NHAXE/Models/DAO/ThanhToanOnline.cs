using Models.ThanhToanOnline;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
   public class ThanhToanOnline
    {
        myWebservice.WebService myservice = new myWebservice.WebService();
        public int listNH(string sotk , int sotien)
        {
            
            int result = myservice.RutTien_TK(sotk, sotien);

            return result;

        }
        public int KiemTraTK(string sotk)
        {

            int result = myservice.Ktra_TK(sotk);

            return result;

        }
    }
}
