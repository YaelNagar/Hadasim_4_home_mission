using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL.models
{
    public partial class HMOCoronaDBContext : DbContext
    {
        public HMOCoronaDBContext()
        {
        }

        public HMOCoronaDBContext(DbContextOptions<HMOCoronaDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CoronaPatients> CoronaPatients { get; set; }
        public virtual DbSet<CoronaVaccines> CoronaVaccines { get; set; }
        public virtual DbSet<Hmomembers> Hmomembers { get; set; }
        public virtual DbSet<VaccineToMember> VaccineToMember { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=HMOCoronaDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CoronaPatients>(entity =>
            {
                entity.Property(e => e.CoronaBeginDate).HasColumnType("date");

                entity.Property(e => e.CoronaEndDate).HasColumnType("date");

                entity.HasOne(d => d.IdMemberNavigation)
                    .WithMany(p => p.CoronaPatients)
                    .HasForeignKey(d => d.IdMember)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CoronaPatients_To_HMOMembers");
            });

            modelBuilder.Entity<CoronaVaccines>(entity =>
            {
                entity.Property(e => e.ManufacturerVaccine).HasMaxLength(50);

                entity.Property(e => e.TypeVaccine)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('first')");
            });

            modelBuilder.Entity<Hmomembers>(entity =>
            {
                entity.ToTable("HMOMembers");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.Identity)
                    .IsRequired()
                    .HasMaxLength(9);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(10);

                entity.Property(e => e.ProfileImage).IsUnicode(false);

                entity.Property(e => e.Telephone).HasMaxLength(10);
            });

            modelBuilder.Entity<VaccineToMember>(entity =>
            {
                entity.HasIndex(e => new { e.IdMember, e.IdVaccine })
                    .HasName("UQ_VaccineToMember_Composite")
                    .IsUnique();

                entity.HasOne(d => d.IdMemberNavigation)
                    .WithMany(p => p.VaccineToMember)
                    .HasForeignKey(d => d.IdMember)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VaccineToMember_To_HMOMembers");

                entity.HasOne(d => d.IdVaccineNavigation)
                    .WithMany(p => p.VaccineToMember)
                    .HasForeignKey(d => d.IdVaccine)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VaccineToMember_To_CoronaVaccines");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
