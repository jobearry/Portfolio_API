using Portfolio_API.Contexts;
using Portfolio_API.Models.EmployeeManagementModels;

namespace Portfolio_API.Repositories.EmployeeManagementRepository
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {

    }
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(EmployeeDbContext context) : base(context)
        {
        }
    }
}
