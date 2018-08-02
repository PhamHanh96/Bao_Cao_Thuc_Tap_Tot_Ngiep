namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DON_HANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DON_HANG()
        {
            THANH_TOAN = new HashSet<THANH_TOAN>();
        }

        [Key]
        public int MA_DH { get; set; }

        [StringLength(100)]
        public string EMAIL_DH { get; set; }

        public int? MA_LT { get; set; }

        public int SOLUONGVE { get; set; }

        public int TONG { get; set; }

        public int? TRANG_THAI { get; set; }

        [StringLength(100)]
        public string EMAIL_NV { get; set; }

        public virtual KHACH_HANG KHACH_HANG { get; set; }

        public virtual LO_TRINH LO_TRINH { get; set; }

        public virtual NHAN_VIEN NHAN_VIEN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THANH_TOAN> THANH_TOAN { get; set; }
    }
}
