using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Portfolio_API.DataTypes.Models.Portfolio;

namespace Portfolio_API.DataAccess.Data.ScaffoldExisting;

public partial class JDBContext : DbContext
{
    public JDBContext(DbContextOptions<JDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Experience> Experiences { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<TechStackDescription> TechStackDescriptions { get; set; }

    public virtual DbSet<TechStackSpec> TechStackSpecs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Experience>(entity =>
        {
            entity.HasKey(e => e.ExperienceId).HasName("PK__experien__EB216AFC5362759B");

            entity.ToTable("experiences");

            entity.Property(e => e.ExperienceId).HasColumnName("experience_id");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(255)
                .HasColumnName("company_name");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Role)
                .HasMaxLength(255)
                .HasColumnName("role");
            entity.Property(e => e.FinishedAt).HasColumnName("finished_at");
        });

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
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.ProjectName)
                .HasMaxLength(255)
                .HasColumnName("project_name");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
        });

        modelBuilder.Entity<TechStackDescription>(entity =>
        {
            entity.HasKey(e => e.StackId).HasName("PK__tech_sta__A44AF9293BF4000B");

            entity.ToTable("tech_stack_description");

            entity.Property(e => e.StackId).HasColumnName("stack_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.StackName)
                .HasMaxLength(255)
                .HasColumnName("stack_name");
        });

        modelBuilder.Entity<TechStackSpec>(entity =>
        {
            entity.HasKey(e => e.SpecId).HasName("PK__tech_sta__F670C567E44DDEB0");

            entity.ToTable("tech_stack_spec");

            entity.Property(e => e.SpecId).HasColumnName("spec_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.ImgSrc)
                .HasMaxLength(255)
                .HasColumnName("img_src");
            entity.Property(e => e.StackId).HasColumnName("stack_id");
            entity.Property(e => e.ToolName)
                .HasMaxLength(255)
                .HasColumnName("tool_name");

            entity.HasOne(d => d.Stack).WithMany(p => p.TechStackSpecs)
                .HasForeignKey(d => d.StackId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_stack_spec_description");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
