using Portfolio_API.DataTypes.Models.EmployeeManagementModels;
using Portfolio_API.DataTypes.Models.EmployeeManagementModels.DTOs;

namespace Portfolio_API.Mapper
{
    public class EmployeeMapper : IMapper<Employee, DTOEmployee>
    {
        public DTOEmployee MapToDto(Employee source)
        {
            return new DTOEmployee
            {
                EmployeeId = source.EmployeeId,
                Name = source.Name,
                Department = source.Department,
                Position = source.Position,
                Email = source.Email
            };
        }
        public Employee MapToEntity(DTOEmployee destination)
        {
            return new Employee
            {
                EmployeeId = destination.EmployeeId,
                Name = destination.Name,
                Department = destination.Department,
                Position = destination.Position,
                Email = destination.Email
            };
        }
        public void UpdateEntity(Employee entity, DTOEmployee dto)
        {
            entity.Name = dto.Name;
            entity.Department = dto.Department;
            entity.Position = dto.Position;
            entity.Email = dto.Email;
        }
    }
}
