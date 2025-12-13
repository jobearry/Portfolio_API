using Portfolio_API.Models.EmployeeManagementModels;
using Portfolio_API.Repositories;

namespace Portfolio_API.Services.EmployeeManagementService
{
    public class UserService
    {
        private readonly ICommonRepository<User> _userRepo;
        public UserService(ICommonRepository<User> userRepo)
        {
            _userRepo = userRepo;
        }
        public async Task<User?> GetUserById(int id)
        {
            return await _userRepo.GetByIdAsync(id);
        }
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _userRepo.GetAllAsync();
        }
    }
}
