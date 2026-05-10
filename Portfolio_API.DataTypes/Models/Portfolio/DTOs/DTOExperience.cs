using System;
using Portfolio_API.DataTypes.Interfaces;

namespace Portfolio_API.DataTypes.Models.Portfolio.DTOs;

public class DTOExperience : IExperience
{  public int ExperienceId { get; set; }
  public string? CompanyName { get; set; }
  public DateTime? FinishedAt { get; set; }
  public string? Description { get; set; }
  public string Role { get; set; } = null!;
  public string? Responsibility { get; set; }
  public string? Type { get; set; }
  public List<DTOProject> Projects { get; set; } = new List<DTOProject>();
}
public class DTOExperienceCreate : IExperience
{
  public int ExperienceId { get; set; }
  public string? CompanyName { get; set; }
  public DateTime? FinishedAt { get; set; }
  public string? Description { get; set; }
  public string Role { get; set; } = null!;
  public string? Responsibility { get; set; }
  public string? Type { get; set; }
}