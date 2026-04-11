using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Portfolio_API.DataAccess.Data.ScaffoldExisting;

public partial class JDBContext : DbContext
{
    public JDBContext(DbContextOptions<JDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Project> Projects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.ProjectId).HasName("PK__projects__BC799E1F26444275");

            entity.ToTable("projects");

            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.Contribution).HasColumnName("contribution");
            entity.Property(e => e.CoverImg)
                .HasMaxLength(255)
                .HasColumnName("cover_img");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.ProjectName)
                .HasMaxLength(255)
                .HasColumnName("project_name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
