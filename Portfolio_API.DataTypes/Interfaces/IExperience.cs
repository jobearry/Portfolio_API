using System;

namespace Portfolio_API.DataTypes.Interfaces;

public interface IExperience
{
  public int ExperienceId { get; set; }
  public string? CompanyName { get; set; }
  public DateTime? FinishedAt { get; set; }
  public string? Description { get; set; }
  public string Role { get; set; }
  public string? Responsibility { get; set; }
  public string? Type { get; set; }
} 