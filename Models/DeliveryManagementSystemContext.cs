using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MyCart.Models
{
    public partial class DeliveryManagementSystemContext : DbContext
    {
        public DeliveryManagementSystemContext()
        {
        }

        public DeliveryManagementSystemContext(DbContextOptions<DeliveryManagementSystemContext> options)
            : base(options)
        {
        }

     
        public virtual DbSet<CustomerRegistration> CustomerRegistrations { get; set; } = null!;
        public virtual DbSet<ExecutiveRegistration> ExecutiveRegistrations { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-CCNCPJ77;Database=DeliveryManagementSystem;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<CustomerRegistration>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK_CId");

                entity.ToTable("CustomerRegistration");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExecutiveRegistration>(entity =>
            {
                entity.HasKey(e => e.ExecutiveId)
                    .HasName("PK_EId");

                entity.ToTable("ExecutiveRegistration");

                entity.Property(e => e.ExecutiveName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
