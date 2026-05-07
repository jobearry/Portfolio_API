using System;
using Portfolio_API.DataTypes.Models.DTOs.Portfolio;
using Portfolio_API.DataTypes.Models.Portfolio;

namespace Portfolio_API.Mapper.Portfolio;

public class ExperiencesMapper: IMapper<Experience, DTOExperience>
{
  public DTOExperience MapToDto(Experience source)
  {
    return new DTOExperience()
    {
      ExperienceId = source.ExperienceId,
      CompanyName = source.CompanyName,
      FinishedAt = source.FinishedAt,
      Description = source.Description,
      Role = source.Role
    };
  }

  public Experience MapToEntity(DTOExperience destination)
  {
    return new Experience()
    {
      ExperienceId = destination.ExperienceId,
      CompanyName = destination.CompanyName,
      FinishedAt = destination.FinishedAt,
      Description = destination.Description,
      Role = destination.Role
    };
  }

  public void UpdateEntity(Experience entity, DTOExperience destination)
  {
    entity.CompanyName = destination.CompanyName;
    entity.ExperienceId = destination.ExperienceId;
    entity.FinishedAt = destination.FinishedAt;
    entity.Description = destination.Description;
    entity.Role = destination.Role;
  }
}
