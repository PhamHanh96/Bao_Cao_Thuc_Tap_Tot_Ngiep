using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NHAXE.Models
{
    public class LoginModel
    {
        [Required]
        [Key]
        public int ID_KH { get; set; }

        [StringLength(50)]
        public string TEN_KH { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "vui lòng nhập email")]
        public string EMAIL_KH { get; set; }

        [StringLength(11)]
        public string SDT_KH { get; set; }

        [StringLength(12)]
        public string CMND_KH { get; set; }

        [StringLength(100)]
        public string DIACHI_KH { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "vui lòng nhập mật khẩu")]
        public string MATKHAU { get; set; }
    }
}