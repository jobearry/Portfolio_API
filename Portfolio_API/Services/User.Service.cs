using Portfolio_API.Models;
using Portfolio_API.Repositories;

namespace Portfolio_API.Services
{
    public class UserService
    {
        private readonly IEmployeeManagementRepository<User> _userRepo;
        public UserService(IEmployeeManagementRepository<User> userRepo)
        {
            _userRepo = userRepo;
        }
        public async Task<User?> GetAttendanceById(int id)
        {
            return await this._userRepo.GetByIdAsync(id);
        }
        public async Task<IEnumerable<User>> GetAttendance()
        {
            return await this._userRepo.GetAllAsync();
        }
    }
}
