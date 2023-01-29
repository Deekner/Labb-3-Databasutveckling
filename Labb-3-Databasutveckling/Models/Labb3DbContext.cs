using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Labb_3_Databasutveckling.Models
{
    public partial class Labb3DbContext : DbContext
    {
        public Labb3DbContext()
        {
        }

        public Labb3DbContext(DbContextOptions<Labb3DbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GradeHistory> GradeHistory { get; set; }
        public virtual DbSet<TblConnect> TblConnect { get; set; }
        public virtual DbSet<TblCourse> TblCourse { get; set; }
        public virtual DbSet<TblEmployee> TblEmployee { get; set; }
        public virtual DbSet<TblGrade> TblGrade { get; set; }
        public virtual DbSet<TblStudent> TblStudent { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source = DESKTOP-HB2LGAV; Initial Catalog = Labb2Uppgift; Integrated Security = True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GradeHistory>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("date");
            });

            modelBuilder.Entity<TblConnect>(entity =>
            {
                entity.HasKey(e => e.TblConnect1);

                entity.ToTable("tblConnect");

                entity.Property(e => e.TblConnect1).HasColumnName("tblConnect");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.GradeId).HasColumnName("GradeID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.TblConnect)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_tblConnect_tblCourse");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.TblConnect)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_tblConnect_tblEmployee");

                entity.HasOne(d => d.Grade)
                    .WithMany(p => p.TblConnect)
                    .HasForeignKey(d => d.GradeId)
                    .HasConstraintName("FK_tblConnect_tblGrade");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.TblConnect)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_tblConnect_tblStudent");
            });

            modelBuilder.Entity<TblCourse>(entity =>
            {
                entity.HasKey(e => e.CourseId);

                entity.ToTable("tblCourse");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.CourseName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.TblCourse)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCourse_tblEmployee");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.TblCourse)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_tblCourse_tblStudent");
            });

            modelBuilder.Entity<TblEmployee>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.ToTable("tblEmployee");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Role).HasMaxLength(50);
            });

            modelBuilder.Entity<TblGrade>(entity =>
            {
                entity.HasKey(e => e.GradeId)
                    .HasName("PK_Grade");

                entity.ToTable("tblGrade");

                entity.Property(e => e.GradeId).HasColumnName("GradeID");

                entity.Property(e => e.Course).HasMaxLength(50);

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.Grade).HasMaxLength(50);

                entity.Property(e => e.GradeSetDate).HasColumnType("date");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.TblGrade)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_tblGrade_tblEmployee");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.TblGrade)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_tblGrade_tblStudent");
            });

            modelBuilder.Entity<TblStudent>(entity =>
            {
                entity.HasKey(e => e.StudentId);

                entity.ToTable("tblStudent");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.Class).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
