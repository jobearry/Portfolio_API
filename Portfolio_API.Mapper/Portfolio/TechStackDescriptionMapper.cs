using System;
using Portfolio_API.DataTypes.Models.Portfolio.DTOs;
using Portfolio_API.DataTypes.Models.Portfolio;

namespace Portfolio_API.Mapper.Portfolio;

public class TechStackDescriptionMapper: IMapper<TechStackDescription, DTOTechStackDescription, DTOTechStackDescription>
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

  public TechStackDescription MapToEntity(DTOTechStackDescription source)
  {
    return new TechStackDescription()
    {
      StackId = source.StackId,
      StackName = source.StackName,
      CreatedAt = source.CreatedAt,
    };
  }

  // public void UpdateEntity(TechStackDescription entity, DTOTechStackDescription destination)
  // {
  //   entity.StackName = destination.StackName;
  //   entity.StackId = destination.StackId;
  //   entity.CreatedAt = destination.CreatedAt;
  // }
}