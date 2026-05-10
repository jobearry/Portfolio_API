using System;

namespace Portfolio_API.DataTypes.Models.Portfolio.DTOs;

public class DTOTechStackDescription
{
  public int StackId { get; set; }

  public string StackName { get; set; } = null!;

  public DateTime? CreatedAt { get; set; }
}
