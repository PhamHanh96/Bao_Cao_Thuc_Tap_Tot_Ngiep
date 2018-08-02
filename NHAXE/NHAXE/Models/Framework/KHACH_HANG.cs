namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KHACH_HANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHACH_HANG()
        {
            DON_HANG = new HashSet<DON_HANG>();
            THANH_TOAN = new HashSet<THANH_TOAN>();
        }
        [Display(Name = "Tên Khách hàng")]
        [Required(ErrorMessage = "vui lòng nhập tên khách hàng")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "độ dài từ 5->50 kí tự")]
        [RegularExpression(@"[A-Za-z ]{5,50}")]
        public string TEN_KH { get; set; }

        [Key]
        [StringLength(100)]
        [Required(ErrorMessage = "vui lòng nhập E-Mail")]
        [RegularExpression(@"[A-Za-z0-9]+@[A-Za-z]+\.[A-Za-z]{2,4}")]
        [Display(Name = "E-Mail")]
        public string EMAIL_KH { get; set; }

        [Required(ErrorMessage = "vui lòng nhập số ĐT")]
        [RegularExpression(@"[0]+[1-28-9]+[0-9]{8,9}")]
        [Display(Name = "Số ĐT")]
        public string SDT_KH { get; set; }

        [StringLength(9)]
        [Required(ErrorMessage = "vui lòng nhập chứng minh nhân dân")]
        [RegularExpression(@"[0-9]{9}")]
        [Display(Name = "Số CMND")]
        public string CMND_KH { get; set; }

        [StringLength(100, ErrorMessage = "độ dài tối đa là 100 kí tự")]
        [Required(ErrorMessage = "vui lòng nhập địa chỉ")]
        [Display(Name = "Địa chỉ")]
        public string DIACHI_KH { get; set; }

        [Required(ErrorMessage = "vui lòng nhập mật khẩu")]
        [StringLength(50, ErrorMessage = "mật khẩu tối đa là 50 kí tự")]
        [Display(Name = "PassWord")]
        public string MATKHAU { get; set; }

        [Required(ErrorMessage = "vui lòng nhập mật khẩu")]
        [StringLength(50, ErrorMessage = "mật khẩu tối đa là 50 kí tự")]
        [Display(Name = "Confirm Pass")]
        [Compare("MATKHAU", ErrorMessage = "Xác nhận mật khẩu không đúng")]
        public string CONFIRM_PASS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DON_HANG> DON_HANG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THANH_TOAN> THANH_TOAN { get; set; }
    }
}
