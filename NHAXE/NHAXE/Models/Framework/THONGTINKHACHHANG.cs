using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Framework
{
    public class THONGTINKHACHHANG
    {
        public KHACH_HANG KhachHang { get; set; }
        public List<THANH_TOAN> ThanhToan { get; set; }
    }
}
