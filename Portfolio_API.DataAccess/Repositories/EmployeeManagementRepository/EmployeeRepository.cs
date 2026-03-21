using Portfolio_API.DataAccess.Contexts;
using Portfolio_API.DataTypes.Models.EmployeeManagementModels;

namespace Portfolio_API.DataAccess.Repositories.EmployeeManagementRepository
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
