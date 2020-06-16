using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebBanHoa.DAL.Models
{
    public partial class WebBanHoaContext : DbContext
    {
        public WebBanHoaContext()
        {
        }

        public WebBanHoaContext(DbContextOptions<WebBanHoaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChiNhanh> ChiNhanh { get; set; }
        public virtual DbSet<ChiTietDonHang> ChiTietDonHang { get; set; }
        public virtual DbSet<DonHang> DonHang { get; set; }
        public virtual DbSet<Hoa> Hoa { get; set; }
        public virtual DbSet<KhachHang> KhachHang { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCap { get; set; }
        public virtual DbSet<NhanVien> NhanVien { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=WebBanHoa;Persist Security Info=True;User ID=sa;Password=1;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiNhanh>(entity =>
            {
                entity.HasKey(e => e.MaChiNhanh);

                entity.Property(e => e.MaChiNhanh).ValueGeneratedNever();

                entity.Property(e => e.DiaChi)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.GiaThue).HasColumnType("datetime");

                entity.Property(e => e.MaNv).HasColumnName("MaNV");

                entity.Property(e => e.NgayHoatDong).HasColumnType("datetime");

                entity.Property(e => e.TenChiNhanh)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.MaNvNavigation)
                    .WithMany(p => p.ChiNhanh)
                    .HasForeignKey(d => d.MaNv)
                    .HasConstraintName("FK_ChiNhanh_NhanVien");
            });

            modelBuilder.Entity<ChiTietDonHang>(entity =>
            {
                entity.HasKey(e => new { e.MaDh, e.MaHoa })
                    .HasName("PK_ChiTietDonHang_1");

                entity.Property(e => e.MaDh).HasColumnName("MaDH");

                entity.Property(e => e.GiamGia)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.SoTien).HasColumnType("money");

                entity.HasOne(d => d.MaDhNavigation)
                    .WithMany(p => p.ChiTietDonHang)
                    .HasForeignKey(d => d.MaDh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietDonHang_DonHang");

                entity.HasOne(d => d.MaHoaNavigation)
                    .WithMany(p => p.ChiTietDonHang)
                    .HasForeignKey(d => d.MaHoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietDonHang_Hoa");
            });

            modelBuilder.Entity<DonHang>(entity =>
            {
                entity.HasKey(e => e.MaDh);

                entity.Property(e => e.MaDh)
                    .HasColumnName("MaDH")
                    .ValueGeneratedNever();

                entity.Property(e => e.DiaChiNhan)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.MaKh).HasColumnName("MaKH");

                entity.Property(e => e.MaNv).HasColumnName("MaNV");

                entity.Property(e => e.NgayDatHoa).HasColumnType("datetime");

                entity.Property(e => e.NgayGiaoHoa).HasColumnType("datetime");

                entity.Property(e => e.NgayNhan).HasColumnType("datetime");

                entity.Property(e => e.NguoiNhan)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.MaKhNavigation)
                    .WithMany(p => p.DonHang)
                    .HasForeignKey(d => d.MaKh)
                    .HasConstraintName("FK_DonHang_KhachHang");

                entity.HasOne(d => d.MaNvNavigation)
                    .WithMany(p => p.DonHang)
                    .HasForeignKey(d => d.MaNv)
                    .HasConstraintName("FK_DonHang_NhanVien");
            });

            modelBuilder.Entity<Hoa>(entity =>
            {
                entity.HasKey(e => e.MaHoa)
                    .HasName("PK_Hoa1");

                entity.Property(e => e.MaHoa).ValueGeneratedNever();

                entity.Property(e => e.GiaBan).HasColumnType("money");

                entity.Property(e => e.GiaMua).HasColumnType("money");

                entity.Property(e => e.Mota).HasColumnType("ntext");

                entity.Property(e => e.TenHoa)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.MaNccNavigation)
                    .WithMany(p => p.Hoa)
                    .HasForeignKey(d => d.MaNcc)
                    .HasConstraintName("FK_Hoa_NhaCungCap");
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.HasKey(e => e.MaKh);

                entity.Property(e => e.MaKh)
                    .HasColumnName("MaKH")
                    .ValueGeneratedNever();

                entity.Property(e => e.DiaChi)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.GioiTinh)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.HoKh)
                    .HasColumnName("HoKH")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Sdt).HasColumnName("SDT");

                entity.Property(e => e.TenKh)
                    .HasColumnName("TenKH")
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<NhaCungCap>(entity =>
            {
                entity.HasKey(e => e.MaNcc);

                entity.Property(e => e.MaNcc).ValueGeneratedNever();

                entity.Property(e => e.DiaChi)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.SoDt).HasColumnName("SoDT");

                entity.Property(e => e.TenNcc)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.MaNv);

                entity.Property(e => e.MaNv)
                    .HasColumnName("MaNV")
                    .ValueGeneratedNever();

                entity.Property(e => e.ChucVu)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.DiaChi)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.GioiTinh)
                    .HasMaxLength(10)
                    .IsFixedLength();


                entity.Property(e => e.HoNv)
                    .HasColumnName("HoNV")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Luong).HasColumnType("money");

                entity.Property(e => e.NgayLam).HasColumnType("datetime");

                entity.Property(e => e.NgaySinh).HasColumnType("datetime");

                entity.Property(e => e.SoCmnd).HasColumnName("SoCMND");

                entity.Property(e => e.TenNv)
                    .HasColumnName("TenNV")
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
