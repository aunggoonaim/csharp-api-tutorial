using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace csharp_api_tutorial.Models
{
    public partial class TutorialContext : DbContext
    {
        public TutorialContext()
        {
        }

        public TutorialContext(DbContextOptions<TutorialContext> options)
            : base(options)
        {
        }

        public virtual DbSet<user_address_info> user_address_infos { get; set; } = null!;
        public virtual DbSet<user_info> user_infos { get; set; } = null!;
        public virtual DbSet<user_role> user_roles { get; set; } = null!;
        public virtual DbSet<user_role_info> user_role_infos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;uid=root;pwd=p@$$w0rd;database=tutorial", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.31-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");

            modelBuilder.Entity<user_address_info>(entity =>
            {
                entity.Property(e => e.created_date).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<user_info>(entity =>
            {
                entity.Property(e => e.created_date).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.user_addr_current)
                    .WithMany(p => p.user_infouser_addr_currents)
                    .HasForeignKey(d => d.user_addr_current_id)
                    .HasConstraintName("user_addr_current");

                entity.HasOne(d => d.user_addr_home)
                    .WithMany(p => p.user_infouser_addr_homes)
                    .HasForeignKey(d => d.user_addr_home_id)
                    .HasConstraintName("user_addr_home");
            });

            modelBuilder.Entity<user_role_info>(entity =>
            {
                entity.Property(e => e.created_date).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.user_info)
                    .WithMany(p => p.user_role_infos)
                    .HasForeignKey(d => d.user_info_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_id");

                entity.HasOne(d => d.user_role)
                    .WithMany(p => p.user_role_infos)
                    .HasForeignKey(d => d.user_role_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("role_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
