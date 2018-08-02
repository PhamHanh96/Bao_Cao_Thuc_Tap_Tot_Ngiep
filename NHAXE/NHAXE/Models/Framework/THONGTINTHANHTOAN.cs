using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Framework
{
    public class THONGTINTHANHTOAN
    {
        public TUYEN_DUONG TD { get; set; }
        public LO_TRINH LT { get; set; }
        public KHACH_HANG KhachHang { get; set; }
        public DON_HANG DonHang { get; set; }
        public string SoTaiKhoan { get; set; }
    }
}
