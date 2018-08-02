namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NHAN_VIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHAN_VIEN()
        {
            DON_HANG = new HashSet<DON_HANG>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Mã NV")]
        public int MA_NV { get; set; }

        [StringLength(15)]
        [Display(Name = "Chức Vụ")]
        public string CHUCVU { get; set; }

        //[StringLength(50)]
        [Display(Name = "Tên Nhân Viên")]
        [Required(ErrorMessage = "Vui lòng nhập tên Nhân Viên")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "độ dài từ 5->50 kí tự")]
        [RegularExpression(@"[A-Za-z ]{5,50}")]
        public string TENNV { get; set; }

        [Key]
        [StringLength(100)]
        [Required(ErrorMessage = "Vui lòng nhập E-Mail")]
        [RegularExpression(@"[A-Za-z0-9]+@[A-Za-z]+\.[A-Za-z]{2,4}")]
        [Display(Name = "Email")]
        public string EMAIL_NV { get; set; }

        [StringLength(11)]
        [Required(ErrorMessage = "vui lòng nhập số ĐT")]
        [RegularExpression(@"[0]+[1-28-9]+[0-9]{8,9}")]
        [Display(Name = "SĐT")]
        public string SDT_NV { get; set; }

        [StringLength(9)]
        [Required(ErrorMessage = "Vui lòng nhập chứng minh nhân dân")]
        [RegularExpression(@"[0-9]{9}")]
        [Display(Name = "CMND")]
        public string CMND_NV { get; set; }

        [StringLength(100, ErrorMessage = "độ dài tối đa là 100 kí tự")]
        [Required(ErrorMessage = "vui lòng nhập địa chỉ")]
        [Display(Name = "Địa Chỉ")]
        public string DIACHI_NV { get; set; }

        [Required(ErrorMessage = "vui lòng nhập mật khẩu")]
        [StringLength(50, ErrorMessage = "mật khẩu tối đa là 50 kí tự")]
        [Display(Name = "Mật khẩu")]
        public string MATKHAU { get; set; }

        [Required(ErrorMessage = "vui lòng nhập mật khẩu")]
        [StringLength(50, ErrorMessage = "mật khẩu tối đa là 50 kí tự")]
        [Display(Name = "Confirm Pass")]
        [Compare("MATKHAU", ErrorMessage = "Xác nhận mật khẩu không đúng")]
        public string CONFIRM_PASS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DON_HANG> DON_HANG { get; set; }
    }
}
