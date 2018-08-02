namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class THANH_TOAN
    {
        [Key]
        public int MA_TT { get; set; }

        public int MA_DH { get; set; }

        [StringLength(100)]
        public string EMAIL { get; set; }

        public DateTime? NGAYMUA { get; set; }

        public virtual DON_HANG DON_HANG { get; set; }

        public virtual KHACH_HANG KHACH_HANG { get; set; }
    }
}
