using System;

namespace Portfolio_API.DataTypes.Models.DTOs.Portfolio;

public class DTOExperience
{
  public int ExperienceId { get; set; }

  public string? CompanyName { get; set; }

  public DateTime? FinishedAt { get; set; }

  public string? Description { get; set; }

  public string Role { get; set; } = null!;
}
