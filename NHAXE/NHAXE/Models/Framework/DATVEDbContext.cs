namespace Models.Framework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DATVEDbContext : DbContext
    {
        public DATVEDbContext()
            : base("name=DATVEDbContext")
        {
        }

        public virtual DbSet<DON_HANG> DON_HANG { get; set; }
        public virtual DbSet<KHACH_HANG> KHACH_HANG { get; set; }
        public virtual DbSet<LO_TRINH> LO_TRINH { get; set; }
        public virtual DbSet<NHAN_VIEN> NHAN_VIEN { get; set; }
        public virtual DbSet<THANH_TOAN> THANH_TOAN { get; set; }
        public virtual DbSet<TUYEN_DUONG> TUYEN_DUONG { get; set; }
        public virtual DbSet<XE_KHACH> XE_KHACH { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DON_HANG>()
                .HasMany(e => e.THANH_TOAN)
                .WithRequired(e => e.DON_HANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHACH_HANG>()
                .HasMany(e => e.DON_HANG)
                .WithOptional(e => e.KHACH_HANG)
                .HasForeignKey(e => e.EMAIL_DH);

            modelBuilder.Entity<KHACH_HANG>()
                .HasMany(e => e.THANH_TOAN)
                .WithOptional(e => e.KHACH_HANG)
                .HasForeignKey(e => e.EMAIL);

            modelBuilder.Entity<XE_KHACH>()
                .HasMany(e => e.LO_TRINH)
                .WithOptional(e => e.XE_KHACH)
                .HasForeignKey(e => e.BSXE);
        }
    }
}
