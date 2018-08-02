namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LO_TRINH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LO_TRINH()
        {
            DON_HANG = new HashSet<DON_HANG>();
        }

        [Key]
        [Display(Name = "Mã Lộ Trình")]
        public int MA_LT { get; set; }

        [StringLength(15)]
        [Display(Name = "Mã tuyến đường")]
        public string MS_TUYEN { get; set; }

        [StringLength(15)]
        [Display(Name = "Bảng số xe")]
        public string BSXE { get; set; }
        [Display(Name = "Ngày khởi Hành")]
        public DateTime? NGAYDI { get; set; }
        [Display(Name = "Giờ khởi hành")]
        public TimeSpan? GIO { get; set; }
        [Display(Name = "Số vé còn")]
        public int GHE_TRONG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DON_HANG> DON_HANG { get; set; }

        public virtual TUYEN_DUONG TUYEN_DUONG { get; set; }

        public virtual XE_KHACH XE_KHACH { get; set; }
    }
}
