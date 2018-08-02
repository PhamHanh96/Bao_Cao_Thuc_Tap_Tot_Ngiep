namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TUYEN_DUONG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TUYEN_DUONG()
        {
            LO_TRINH = new HashSet<LO_TRINH>();
        }

        [Key]
        [StringLength(15)]
        [Display(Name = "Mã Tuyến Ðường")]
        public string MS_TUYEN { get; set; }

        [StringLength(15)]
        [Display(Name = "Bến Ði")]
        public string BENDI { get; set; }

        [StringLength(15)]
        [Display(Name = "Bến Ðến")]
        public string BENDEN { get; set; }

        [Display(Name = "Quãng Ðường")]
        public int? QUANGDUONG { get; set; }

        [Display(Name = "Thời Gian")]
        public TimeSpan? THOIGIAN { get; set; }

        [Display(Name = "Giá Vé")]
        public int GIAVE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LO_TRINH> LO_TRINH { get; set; }
    }
}
