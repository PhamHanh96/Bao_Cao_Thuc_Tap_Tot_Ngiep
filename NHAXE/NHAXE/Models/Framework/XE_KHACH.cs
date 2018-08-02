namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class XE_KHACH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public XE_KHACH()
        {
            LO_TRINH = new HashSet<LO_TRINH>();
        }

        [Key]
        [StringLength(15)]
        [Display(Name = "Bảng số xe")]
        public string MA_BSX { get; set; }
        [Display(Name = "Số chổ")]
        public int SOCHO { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LO_TRINH> LO_TRINH { get; set; }
    }
}
