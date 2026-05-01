using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Portfolio_API.DataTypes.Models.Portfolio;

namespace Portfolio_API.DataAccess.Contexts;

public partial class JDBContext : DbContext
{
    public JDBContext(DbContextOptions<JDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ExpProject> ExpProjects { get; set; }

    public virtual DbSet<Experience> Experiences { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<TechStackDescription> TechStackDescriptions { get; set; }

    public virtual DbSet<TechStackSpec> TechStackSpecs { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ExpProject>(entity =>
        {
            entity.HasKey(e => new { e.ProjectId, e.TechstackId, e.ExperiencedAt }).HasName("PK_ProjectTechStack");

            entity.ToTable("exp_projects");

            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.TechstackId).HasColumnName("techstack_id");
            entity.Property(e => e.ExperiencedAt)
                .HasDefaultValue(1)
                .HasColumnName("experienced_at");

            entity.HasOne(d => d.ExperiencedAtNavigation).WithMany(p => p.ExpProjects)
                .HasForeignKey(d => d.ExperiencedAt)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjectTechStack_Experience");

            entity.HasOne(d => d.Project).WithMany(p => p.ExpProjects)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjectTechStack_Project");

            entity.HasOne(d => d.Techstack).WithMany(p => p.ExpProjects)
                .HasForeignKey(d => d.TechstackId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjectTechStack_TechStack");
        });

        modelBuilder.Entity<Experience>(entity =>
        {
            entity.HasKey(e => e.ExperienceId).HasName("PK__experien__EB216AFCB14726DD");

            entity.ToTable("experiences");

            entity.Property(e => e.ExperienceId).HasColumnName("experience_id");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(255)
                .HasColumnName("company_name");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.FinishedAt).HasColumnName("finished_at");
            entity.Property(e => e.Role)
                .HasMaxLength(255)
                .HasColumnName("role");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.ProjectId).HasName("PK__projects__BC799E1F2A481118");

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
            entity.HasKey(e => e.StackId).HasName("PK__tech_sta__A44AF929B7A3A9B6");

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
            entity.HasKey(e => e.SpecId).HasName("PK__tech_sta__F670C567B3B5AEFC");

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

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.Location)
                .HasMaxLength(50)
                .HasColumnName("location");
            entity.Property(e => e.UserName)
                .HasMaxLength(22)
                .HasColumnName("user_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
