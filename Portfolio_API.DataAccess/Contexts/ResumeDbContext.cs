using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Portfolio_API.DataTypes.Models.Resume;

namespace Portfolio_API.DataAccess.Contexts;

public partial class ResumeDbContext : DbContext
{
    public ResumeDbContext()
    {
    }

    public ResumeDbContext(DbContextOptions<ResumeDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Experience> Experiences { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Experience>(entity =>
        {
            entity.ToTable("experiences");

            entity.HasIndex(e => e.ExperienceId, "IX_experiences_experience_id").IsUnique();

            entity.Property(e => e.ExperienceId).HasColumnName("experience_id");
            entity.Property(e => e.CompanyName)
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("company_name");
            entity.Property(e => e.Description)
                .HasColumnType("varchar(255)")
                .HasColumnName("description");
            entity.Property(e => e.StartedAt)
                .HasColumnType("varchar(255)")
                .HasColumnName("started_at");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.ToTable("projects");

            entity.HasIndex(e => e.ProjectId, "IX_projects_project_id").IsUnique();

            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.CoverImg)
                .HasColumnType("varchar(255)")
                .HasColumnName("cover_img");
            entity.Property(e => e.Description)
                .HasColumnType("varchar(255)")
                .HasColumnName("description");
            entity.Property(e => e.Duration)
                .HasColumnType("varchar(255)")
                .HasColumnName("duration");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
