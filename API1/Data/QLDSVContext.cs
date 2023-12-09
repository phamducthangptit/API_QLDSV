using System;
using System.Collections.Generic;
using API1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API1.Data
{
    public partial class QLDSVContext : DbContext
    {
        public QLDSVContext()
        {
        }

        public QLDSVContext(DbContextOptions<QLDSVContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CtLopTinChi> CtLopTinChis { get; set; } = null!;
        public virtual DbSet<GiangVien> GiangViens { get; set; } = null!;
        public virtual DbSet<HocKi> HocKis { get; set; } = null!;
        public virtual DbSet<KhoaHoc> KhoaHocs { get; set; } = null!;
        public virtual DbSet<Lop> Lops { get; set; } = null!;
        public virtual DbSet<MonHoc> MonHocs { get; set; } = null!;
        public virtual DbSet<NguoiQt> NguoiQts { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<SinhVien> SinhViens { get; set; } = null!;
        public virtual DbSet<SvHocLopTinChi> SvHocLopTinChis { get; set; } = null!;
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=MSI;Database=QLDSV;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CtLopTinChi>(entity =>
            {
                entity.ToTable("CT_LopTinChi");

                entity.HasIndex(e => new { e.MaHk, e.MaLop, e.MaMh, e.MaNhom, e.MaGv }, "UK_CT_LopTinChi")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.MaGv)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MaGV");

                entity.Property(e => e.MaHk)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MaHK");

                entity.Property(e => e.MaLop)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.MaMh)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MaMH");

                entity.Property(e => e.NgayBdhoc)
                    .HasColumnType("date")
                    .HasColumnName("NgayBDHoc");

                entity.Property(e => e.NgayKthoc)
                    .HasColumnType("date")
                    .HasColumnName("NgayKTHoc");

                entity.Property(e => e.SlthucTeDk).HasColumnName("SLThucTeDK");

                entity.Property(e => e.SltoiDa).HasColumnName("SLToiDa");

                entity.HasOne(d => d.MaGvNavigation)
                    .WithMany(p => p.CtLopTinChis)
                    .HasForeignKey(d => d.MaGv)
                    .HasConstraintName("FK_CT_MonHoc_GiangVien");

                entity.HasOne(d => d.MaHkNavigation)
                    .WithMany(p => p.CtLopTinChis)
                    .HasForeignKey(d => d.MaHk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CT_MonHoc_HocKi");

                entity.HasOne(d => d.MaLopNavigation)
                    .WithMany(p => p.CtLopTinChis)
                    .HasForeignKey(d => d.MaLop)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CT_MonHoc_Lop");

                entity.HasOne(d => d.MaMhNavigation)
                    .WithMany(p => p.CtLopTinChis)
                    .HasForeignKey(d => d.MaMh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CT_MonHoc_MonHoc1");
            });

            modelBuilder.Entity<GiangVien>(entity =>
            {
                entity.HasKey(e => e.MaGv);

                entity.ToTable("GiangVien");

                entity.Property(e => e.MaGv)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MaGV");

                entity.Property(e => e.Email1).HasMaxLength(50);

                entity.Property(e => e.Email2).HasMaxLength(50);

                entity.Property(e => e.GioiTinh).HasMaxLength(10);

                entity.Property(e => e.HoTen).HasMaxLength(100);

                entity.Property(e => e.HocHam).HasMaxLength(50);

                entity.Property(e => e.NgaySinh).HasColumnType("date");

                entity.Property(e => e.QueQuan).HasMaxLength(200);

                entity.Property(e => e.Sdt1)
                    .HasMaxLength(50)
                    .HasColumnName("SDT1");

                entity.Property(e => e.Sdt2)
                    .HasMaxLength(50)
                    .HasColumnName("SDT2");

                entity.HasOne(d => d.MaGvNavigation)
                    .WithOne(p => p.GiangVien)
                    .HasForeignKey<GiangVien>(d => d.MaGv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GiangVien_TaiKhoan");
            });

            modelBuilder.Entity<HocKi>(entity =>
            {
                entity.HasKey(e => e.MaHk);

                entity.ToTable("HocKi");

                entity.Property(e => e.MaHk)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MaHK");

                entity.Property(e => e.NgayBd)
                    .HasColumnType("date")
                    .HasColumnName("NgayBD");

                entity.Property(e => e.NgayKt)
                    .HasColumnType("date")
                    .HasColumnName("NgayKT");
            });

            modelBuilder.Entity<KhoaHoc>(entity =>
            {
                entity.HasKey(e => e.MaKh);

                entity.ToTable("KhoaHoc");

                entity.Property(e => e.MaKh)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MaKH");

                entity.Property(e => e.NamBd).HasColumnName("NamBD");

                entity.Property(e => e.NamKt).HasColumnName("NamKT");
            });

            modelBuilder.Entity<Lop>(entity =>
            {
                entity.HasKey(e => e.MaLop);

                entity.ToTable("Lop");

                entity.Property(e => e.MaLop)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.MaKh)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MaKH");

                entity.Property(e => e.TenLop).HasMaxLength(100);

                entity.HasOne(d => d.MaKhNavigation)
                    .WithMany(p => p.Lops)
                    .HasForeignKey(d => d.MaKh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lop_KhoaHoc");
            });

            modelBuilder.Entity<MonHoc>(entity =>
            {
                entity.HasKey(e => e.MaMh);

                entity.ToTable("MonHoc");

                entity.Property(e => e.MaMh)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MaMH");

                entity.Property(e => e.PhanTramDiemCc).HasColumnName("PhanTramDiemCC");

                entity.Property(e => e.PhanTramDiemKt).HasColumnName("PhanTramDiemKT");

                entity.Property(e => e.PhanTramDiemTh).HasColumnName("PhanTramDiemTH");

                entity.Property(e => e.Stc).HasColumnName("STC");

                entity.Property(e => e.Stchp).HasColumnName("STCHP");

                entity.Property(e => e.TenMh)
                    .HasMaxLength(50)
                    .HasColumnName("TenMH");
            });

            modelBuilder.Entity<NguoiQt>(entity =>
            {
                entity.HasKey(e => e.MaNguoiQt);

                entity.ToTable("NguoiQT");

                entity.Property(e => e.MaNguoiQt)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MaNguoiQT");

                entity.Property(e => e.Email1).HasMaxLength(50);

                entity.Property(e => e.Email2).HasMaxLength(50);

                entity.Property(e => e.GioiTinh).HasMaxLength(10);

                entity.Property(e => e.HoTen).HasMaxLength(100);

                entity.Property(e => e.NgaySinh).HasColumnType("date");

                entity.Property(e => e.QueQuan).HasMaxLength(200);

                entity.Property(e => e.Sdt1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SDT1")
                    .IsFixedLength();

                entity.Property(e => e.Sdt2)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SDT2")
                    .IsFixedLength();

                entity.HasOne(d => d.MaNguoiQtNavigation)
                    .WithOne(p => p.NguoiQt)
                    .HasForeignKey<NguoiQt>(d => d.MaNguoiQt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NguoiQT_TaiKhoan1");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.MaRole);

                entity.ToTable("Role");

                entity.Property(e => e.TenRole).HasMaxLength(50);
            });

            modelBuilder.Entity<SinhVien>(entity =>
            {
                entity.HasKey(e => e.MaSv);

                entity.ToTable("SinhVien");

                entity.Property(e => e.MaSv)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MaSV");

                entity.Property(e => e.Email1).HasMaxLength(50);

                entity.Property(e => e.Email2).HasMaxLength(50);

                entity.Property(e => e.GioiTinh).HasMaxLength(10);

                entity.Property(e => e.HoTen).HasMaxLength(100);

                entity.Property(e => e.MaLop)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.NgaySinh).HasColumnType("date");

                entity.Property(e => e.QueQuan).HasMaxLength(200);

                entity.Property(e => e.Sdt1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SDT1");

                entity.Property(e => e.Sdt2)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SDT2");

                entity.HasOne(d => d.MaLopNavigation)
                    .WithMany(p => p.SinhViens)
                    .HasForeignKey(d => d.MaLop)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SinhVien_Lop");

                entity.HasOne(d => d.MaSvNavigation)
                    .WithOne(p => p.SinhVien)
                    .HasForeignKey<SinhVien>(d => d.MaSv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SinhVien_TaiKhoan");
            });

            modelBuilder.Entity<SvHocLopTinChi>(entity =>
            {
                entity.HasKey(e => e.Idct)
                    .HasName("PK_CT_LopTinChi_SinhVien");

                entity.ToTable("SV_HocLopTinChi");

                entity.HasIndex(e => new { e.Id, e.MaSv }, "UK_SV_HocLopTinChi")
                    .IsUnique();

                entity.Property(e => e.Idct)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IDCT");

                entity.Property(e => e.DiemCc).HasColumnName("DiemCC");

                entity.Property(e => e.DiemKt).HasColumnName("DiemKT");

                entity.Property(e => e.DiemTh).HasColumnName("DiemTH");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MaNguoiQt)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MaNguoiQT");

                entity.Property(e => e.MaSv)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MaSV");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.SvHocLopTinChis)
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SV_HocLopTinChi_CT_LopTinChi");

                entity.HasOne(d => d.MaNguoiQtNavigation)
                    .WithMany(p => p.SvHocLopTinChis)
                    .HasForeignKey(d => d.MaNguoiQt)
                    .HasConstraintName("FK_SV_HocLopTinChi_NguoiQT");

                entity.HasOne(d => d.MaSvNavigation)
                    .WithMany(p => p.SvHocLopTinChis)
                    .HasForeignKey(d => d.MaSv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SV_HocLopTinChi_SinhVien");
            });

            modelBuilder.Entity<TaiKhoan>(entity =>
            {
                entity.HasKey(e => e.TenDn);

                entity.ToTable("TaiKhoan");

                entity.Property(e => e.TenDn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TenDN");

                entity.Property(e => e.Password).HasMaxLength(500);

                entity.HasOne(d => d.MaRoleNavigation)
                    .WithMany(p => p.TaiKhoans)
                    .HasForeignKey(d => d.MaRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TaiKhoan_Role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
