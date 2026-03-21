using Portfolio_API.DataTypes.Models.EmployeeManagementModels;
using Portfolio_API.DataTypes.Models.EmployeeManagementModels.DTOs;

namespace Portfolio_API.Mapper.EmployeeManagement
{
    public class UserMapper : IMapper<User, DTOUser>
    {
        public DTOUser MapToDto(User source)
        {
            return new DTOUser
            {
                UserId = source.UserId,
                EmployeeId = source.EmployeeId,
                Username = source.Username,
                PasswordHash = source.PasswordHash,
                Role = source.Role
            };
        }
        public User MapToEntity(DTOUser destination)
        {
            return new User
            {
                UserId = destination.UserId,
                EmployeeId = destination.EmployeeId,
                Username = destination.Username,
                PasswordHash = destination.PasswordHash,
                Role = destination.Role
            };
        }
        public void UpdateEntity(User entity, DTOUser destination)
        {
            entity.EmployeeId = destination.EmployeeId;
            entity.Username = destination.Username;
            entity.PasswordHash = destination.PasswordHash;
            entity.Role = destination.Role;
        }
    }
}
