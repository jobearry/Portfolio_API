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
    public virtual DbSet<TechStackDescription> TechStackDescriptions { get; set; }

    public virtual DbSet<TechStackSpec> TechStackSpecs { get; set; }

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

        modelBuilder.Entity<TechStackDescription>(entity =>
                {
                    entity.ToTable("tech_stack_description");

                    entity.HasIndex(e => e.Id, "IX_tech_stack_description_id").IsUnique();

                    entity.Property(e => e.Id).HasColumnName("id");
                    entity.Property(e => e.CreatedAt)
                        .HasDefaultValueSql("CURRENT_TIMESTAMP")
                        .HasColumnType("datetime")
                        .HasColumnName("created_at");
                    entity.Property(e => e.StackName)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("stack_name");
                });

        modelBuilder.Entity<TechStackSpec>(entity =>
        {
            entity.ToTable("tech_stack_spec");

            entity.HasIndex(e => e.Id, "IX_tech_stack_spec_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("DATETIME")
                .HasColumnName("created_at");
            entity.Property(e => e.ImgSrc)
                .HasColumnType("varchar(255)")
                .HasColumnName("img_src");
            entity.Property(e => e.StackId)
                .HasColumnType("INT")
                .HasColumnName("stack_id");
            entity.Property(e => e.ToolName)
                .HasColumnType("varchar(255)")
                .HasColumnName("tool_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
