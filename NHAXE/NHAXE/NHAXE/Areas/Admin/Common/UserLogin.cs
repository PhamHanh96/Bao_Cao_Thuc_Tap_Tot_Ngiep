using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHAXE
{
    [Serializable]
    public class UserLogin
    {
        public int Userid { get; set; }
        public string Email { get; set; }
        public String TENNV { get; set; }
        public String CHUCVU_NV { get; set; }
    }
}