using System;
using Portfolio_API.DataTypes.Models.DTOs;
using Portfolio_API.DataTypes.Models.Portfolio;

namespace Portfolio_API.Mapper.Portfolio;

public class TechStackSpecMapper : IMapper<TechStackSpec, DTOTechStackSpec>
{
  public DTOTechStackSpec MapToDto(TechStackSpec source)
  {
    return new DTOTechStackSpec()
    {
      SpecId = source.SpecId,
      ToolName = source.ToolName,
      ImgSrc = source.ImgSrc,
      CreatedAt = source.CreatedAt,
      StackId = source.StackId
    };
  }

  public TechStackSpec MapToEntity(DTOTechStackSpec destination)
  {
    return new TechStackSpec()
    {
      SpecId = destination.SpecId,
      ToolName = destination.ToolName,
      ImgSrc = destination.ImgSrc,
      CreatedAt = destination.CreatedAt,
      StackId = destination.StackId
    };
  }

  public void UpdateEntity(TechStackSpec entity, DTOTechStackSpec destination)
  {
    entity.ToolName = destination.ToolName;
    entity.ImgSrc = destination.ImgSrc;
    entity.StackId = destination.StackId;
  }
}
