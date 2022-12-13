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

        public TutorialContext(DbContextOptions<TutorialContext> options) : base(options)
        {
        }

        public virtual DbSet<user_info> user_infos { get; set; } = null!;
        public virtual DbSet<user_role> user_roles { get; set; } = null!;

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

            modelBuilder.Entity<user_info>(entity =>
            {
                entity.HasOne(d => d.user_role)
                    .WithMany(p => p.user_infos)
                    .HasForeignKey(d => d.user_role_id)
                    .HasConstraintName("user_role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
