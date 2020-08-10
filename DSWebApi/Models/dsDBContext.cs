using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DSWebApi.Models
{
    public partial class dsDBContext : DbContext
    {
        public dsDBContext()
        {
        }

        public dsDBContext(DbContextOptions<dsDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Exam> Exams { get; set; }
        public virtual DbSet<Professor> Professors { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=dsDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PK__Departme__737584F799733FA7");

                entity.ToTable("Department");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Comment).IsUnicode(false);
            });

            modelBuilder.Entity<Exam>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Exam");

                entity.Property(e => e.Points).HasColumnType("decimal(3, 2)");

                entity.Property(e => e.ProfessorId)
                    .HasColumnName("ProfessorID")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.StudentId)
                    .HasColumnName("StudentID")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.Subject)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Professor)
                    .WithMany()
                    .HasForeignKey(d => d.ProfessorId)
                    .HasConstraintName("FK__Exam__ProfessorI__440B1D61");

                entity.HasOne(d => d.Student)
                    .WithMany()
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__Exam__Grade__4222D4EF");

                entity.HasOne(d => d.SubjectNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Subject)
                    .HasConstraintName("FK__Exam__Subject__4316F928");
            });

            modelBuilder.Entity<Professor>(entity =>
            {
                entity.ToTable("Professor");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PK__Role__737584F7BE7A0115");

                entity.ToTable("Role");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasKey(e => e.Status1)
                    .HasName("PK__Status__3A15923EF16ED1F0");

                entity.Property(e => e.Status1)
                    .HasColumnName("Status")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.Index)
                    .HasName("PK__Student__9A5B6228CB52CE46");

                entity.ToTable("Student");

                entity.Property(e => e.Index)
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.Birthdate).HasColumnType("date");

                entity.Property(e => e.Department)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("FK__Student__Status__38996AB5");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PK__Subject__737584F7E71FA58C");

                entity.ToTable("Subject");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Department)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProfessorId)
                    .HasColumnName("ProfessorID")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.HasOne(d => d.DepartmentNavigation)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.Department)
                    .HasConstraintName("FK__Subject__Profess__3F466844");

                entity.HasOne(d => d.Professor)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.ProfessorId)
                    .HasConstraintName("FK__Subject__Profess__403A8C7D");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__User__536C85E579B9BC82");

                entity.ToTable("User");

                entity.Property(e => e.Username)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastLogin).HasColumnType("date");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.RoleNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Role)
                    .HasConstraintName("FK__User__LastLogin__48CFD27E");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
