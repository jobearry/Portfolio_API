using System;
using Portfolio_API.DataTypes.Models.Portfolio.DTOs;
using Portfolio_API.DataTypes.Models.Portfolio;

namespace Portfolio_API.Mapper.Portfolio;

public class TechStackDescriptionMapper : IMapper<TechStackDescription, DTOTechStackDescription, DTOTechStackDescription>
{
  public DTOTechStackDescription MapToDto(TechStackDescription source)
  {
    return new DTOTechStackDescription()
    {
      StackId = source.StackId,
      StackName = source.StackName,
      CreatedAt = source.CreatedAt
    };
  }

  public TechStackDescription MapToEntity(DTOTechStackDescription createDto)
  {
    return new TechStackDescription()
    {
      StackName = createDto.StackName,
      CreatedAt = DateTime.UtcNow
    };
  }
}