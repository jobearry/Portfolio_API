using System;
using Portfolio_API.DataTypes.Models.Portfolio;
using Portfolio_API.DataTypes.Models.Portfolio.DTOs;

namespace Portfolio_API.Mapper.Portfolio;

public class TechStackSpecMapper: IMapper<TechStackSpec, DTOTechStackSpec, DTOTechStackSpec>
{
  public DTOTechStackSpec MapToDto(TechStackSpec source)
  {
    return new DTOTechStackSpec()
    {
      SpecId = source.SpecId,
      ToolName = source.ToolName,
      ImgSrc = source.ImgSrc,
      StackId = source.StackId
    };
  }

  public TechStackSpec MapToEntity(DTOTechStackSpec createDto)
  {
    return new TechStackSpec()
    {
      ToolName = createDto.ToolName,
      ImgSrc = createDto.ImgSrc,
      StackId = createDto.StackId
    };
  }

}
