namespace Web_TraSua.Models.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ShopModelData : DbContext
    {
        public ShopModelData()
            : base("name=MyClassDbContext")
        {
        }

        public virtual DbSet<CTDatHang> CTDatHangs { get; set; }
        public virtual DbSet<DatHang> DatHangs { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LoaiTraSua> LoaiTraSuas { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<TraSua> TraSuas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CTDatHang>()
                .Property(e => e.dongia)
                .HasPrecision(15, 2);

            modelBuilder.Entity<CTDatHang>()
                .Property(e => e.thanhtien)
                .HasPrecision(15, 2);

            modelBuilder.Entity<DatHang>()
                .Property(e => e.tongtien)
                .HasPrecision(15, 2);

            modelBuilder.Entity<DatHang>()
                .HasMany(e => e.CTDatHangs)
                .WithRequired(e => e.DatHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.sdt)
                .IsFixedLength();

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.email)
                .IsFixedLength();

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.taikhoan)
                .IsFixedLength();

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.matkhau)
                .IsFixedLength();

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.taikhoannv)
                .IsFixedLength();

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.matkhaunv)
                .IsFixedLength();

            modelBuilder.Entity<TraSua>()
                .Property(e => e.size)
                .IsFixedLength();

            modelBuilder.Entity<TraSua>()
                .Property(e => e.dongia)
                .HasPrecision(15, 2);
        }
    }
}
