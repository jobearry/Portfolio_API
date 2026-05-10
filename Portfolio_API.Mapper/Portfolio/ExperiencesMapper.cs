using System;
using Portfolio_API.DataTypes.Models.Portfolio.DTOs;
using Portfolio_API.DataTypes.Models.Portfolio;
using Portfolio_API.DataTypes.Interfaces;

namespace Portfolio_API.Mapper.Portfolio;

public class ExperiencesReadMapper: IMapper<Experience, DTOExperience, DTOExperienceCreate>
{
  public DTOExperience MapToDto(Experience source)
  {
    return new DTOExperience()
    {
      ExperienceId = source.ExperienceId,
      CompanyName = source.CompanyName,
      FinishedAt = source.FinishedAt,
      Description = source.Description,
      Responsibility = source.Responsibility,
      Type = source.Type,
      Role = source.Role
    };
  }

  public Experience MapToEntity(DTOExperienceCreate source)
  {
    return new Experience()
    {
      ExperienceId = source.ExperienceId,
      CompanyName = source.CompanyName,
      FinishedAt = source.FinishedAt,
      Description = source.Description,
      Responsibility = source.Responsibility,
      Type = source.Type,
      Role = source.Role
    };
  }
}