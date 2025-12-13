using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Portfolio_API.Models;
using Portfolio_API.Models.EmployeeManagementModels;

namespace Portfolio_API.Contexts;

public partial class PortfolioDbContext : DbContext
{
    public PortfolioDbContext()
    {
    }

    public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attendance> Attendances { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Experience> Experiences { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //for portfolio sections
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
        //===============================================

        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.ToTable("attendance");

            entity.Property(e => e.AttendanceId).HasColumnName("attendance_id");
            entity.Property(e => e.CheckIn).HasColumnName("check_in");
            entity.Property(e => e.CheckOut).HasColumnName("check_out");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.Employee).WithMany(p => p.Attendances)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("employees");

            entity.HasIndex(e => e.Email, "IX_employees_email").IsUnique();

            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.Department).HasColumnName("department");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Position).HasColumnName("position");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users");

            entity.HasIndex(e => e.Username, "IX_users_username").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.PasswordHash).HasColumnName("password_hash");
            entity.Property(e => e.Role).HasColumnName("role");
            entity.Property(e => e.Username).HasColumnName("username");

            entity.HasOne(d => d.Employee).WithMany(p => p.Users)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
