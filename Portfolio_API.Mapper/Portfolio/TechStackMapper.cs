using System;
using Portfolio_API.DataTypes.Models.Portfolio.DTOs;
using Portfolio_API.DataTypes.Models.Portfolio;

namespace Portfolio_API.Mapper.Portfolio;

public interface ITechStackMapper
{
  DTOTechStack MapToDto(TechStackSpec sourceSpec, TechStackDescription sourceDesc);
}

public class TechStackMapper : ITechStackMapper
{
  public DTOTechStack MapToDto(TechStackSpec sourceSpec, TechStackDescription sourceDesc)
  {
    return new DTOTechStack()
    {
      StackId = sourceDesc.StackId,
      StackName = sourceDesc.StackName,
      TechStackSpecs = new List<DTOTechStackSpec>()
      {
        new DTOTechStackSpec()
        {
          SpecId = sourceSpec.SpecId,
          ToolName = sourceSpec.ToolName,
          ImgSrc = sourceSpec.ImgSrc,
          StackId = sourceSpec.StackId
        }
      }
    };
  }
}
