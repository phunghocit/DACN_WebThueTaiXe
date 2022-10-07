﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API_3.Database
{
    public partial class thuetaixeDbContext : DbContext
    {
        public thuetaixeDbContext()
        {
        }

        public thuetaixeDbContext(DbContextOptions<thuetaixeDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChucVu> ChucVus { get; set; }
        public virtual DbSet<DatChuyen> DatChuyens { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<PhanQuyen> PhanQuyens { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=CHITHIEN;Initial Catalog=thuetaixe;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChucVu>(entity =>
            {
                entity.HasKey(e => e.IDChucVu)
                    .HasName("PK_ChucVU");

                entity.ToTable("ChucVu");

                entity.Property(e => e.MoTa).HasMaxLength(50);

                entity.Property(e => e.TenChucVu)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<DatChuyen>(entity =>
            {
                entity.HasKey(e => e.IDChuyen);

                entity.ToTable("DatChuyen");

                entity.Property(e => e.DiemDon).HasMaxLength(100);

                entity.Property(e => e.DiemKetThuc).HasMaxLength(100);

                entity.Property(e => e.GiaTien).HasColumnType("money");

                entity.Property(e => e.ThoiGianDon).HasColumnType("datetime");

                entity.Property(e => e.ThoiGianKetThuc).HasColumnType("datetime");

                entity.Property(e => e.TrangThai).HasMaxLength(50);

                entity.HasOne(d => d.IDKhachHangNavigation)
                    .WithMany(p => p.DatChuyens)
                    .HasForeignKey(d => d.IDKhachHang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DatChuyen_KhachHang");

                entity.HasOne(d => d.IDTaiXeNavigation)
                    .WithMany(p => p.DatChuyenIDTaiXeNavigations)
                    .HasForeignKey(d => d.IDTaiXe)
                    .HasConstraintName("FK_DatChuyen_NhanVien");

                entity.HasOne(d => d.IDTongDaiVienNavigation)
                    .WithMany(p => p.DatChuyenIDTongDaiVienNavigations)
                    .HasForeignKey(d => d.IDTongDaiVien)
                    .HasConstraintName("FK_DatChuyen_NhanVien1");
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.HasKey(e => e.IDKhachHang);

                entity.ToTable("KhachHang");

                entity.Property(e => e.DiaChi).HasMaxLength(50);

                entity.Property(e => e.DienThoai)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.HoTen)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Image)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IDTaiKhoanNavigation)
                    .WithMany(p => p.KhachHangs)
                    .HasForeignKey(d => d.IDTaiKhoan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KhachHang_TaiKhoan");
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.IDNhanVien);

                entity.ToTable("NhanVien");

                entity.Property(e => e.DiaChi).HasMaxLength(50);

                entity.Property(e => e.DienThoai)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.HoTen).HasMaxLength(50);

                entity.Property(e => e.Image)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IDQuyenNavigation)
                    .WithMany(p => p.NhanViens)
                    .HasForeignKey(d => d.IDQuyen)
                    .HasConstraintName("FK_NhanVien_PhanQuyen");

                entity.HasOne(d => d.IDTaiKhoanNavigation)
                    .WithMany(p => p.NhanViens)
                    .HasForeignKey(d => d.IDTaiKhoan)
                    .HasConstraintName("FK_NhanVien_TaiKhoan");
            });

            modelBuilder.Entity<PhanQuyen>(entity =>
            {
                entity.HasKey(e => e.IDQuyen);

                entity.ToTable("PhanQuyen");

                entity.Property(e => e.MoTa).HasMaxLength(100);

                entity.Property(e => e.TenQuyen)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.IDChucVuNavigation)
                    .WithMany(p => p.PhanQuyens)
                    .HasForeignKey(d => d.IDChucVu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PhanQuyen_ChucVu");
            });

            modelBuilder.Entity<TaiKhoan>(entity =>
            {
                entity.HasKey(e => e.IDTaiKhoan);

                entity.ToTable("TaiKhoan");

                entity.Property(e => e.MatKhau)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TenTaiKhoan)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Token)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.TrangThai).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}