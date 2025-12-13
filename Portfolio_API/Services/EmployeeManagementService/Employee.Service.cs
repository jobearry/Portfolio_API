using Microsoft.EntityFrameworkCore;
using Portfolio_API.Contexts;
using Portfolio_API.Models.EmployeeManagementModels;
using Portfolio_API.Repositories;

namespace Portfolio_API.Services.EmployeeManagementService
{
    public class EmployeeService
    {
        private readonly ICommonRepository<Employee> _commonRepo;
        private readonly PortfolioDbContext _context;

        public EmployeeService(ICommonRepository<Employee> commonRepo, PortfolioDbContext context)
        {
            _commonRepo = commonRepo;
            _context = context;
        }

        public async Task<IEnumerable<EmployeeDTO>> ViewAllEmployees()
        {
            var employees = await _commonRepo.GetAllAsync();
            return employees.Select(e => new EmployeeDTO
            {
                EmployeeId = e.EmployeeId,
                Name = e.Name,
                Department = e.Department,
                Position = e.Position,
                Email = e.Email
            }).ToList();
        }

        public async Task<EmployeeDTO?> ViewEmployeeById(int id)
        {
            var employee = await _commonRepo.GetByIdAsync(id);
            if (employee == null) return null;
            return new EmployeeDTO
            {
                EmployeeId = employee.EmployeeId,
                Name = employee.Name,
                Department = employee.Department,
                Position = employee.Position,
                Email = employee.Email
            };
        }

        public async Task<EmployeeDTO> AddEmployee(EmployeeDTO employee)
        {
            //map dto to entity
            var newEmployee = new Employee
            {
                Name = employee.Name,
                Department = employee.Department,
                Position = employee.Position,
                Email = employee.Email
            };

            // start transaction
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var result = await _commonRepo.AddAsync(newEmployee);
                await _context.SaveChangesAsync(); // commit changes to DB

                // commit transaction
                await transaction.CommitAsync();

                // map entity back to dto
                return new EmployeeDTO
                {
                    EmployeeId = result.EmployeeId,
                    Name = result.Name,
                    Department = result.Department,
                    Position = result.Position,
                    Email = result.Email
                };
            }
            catch
            {
                // rollback if anything fails
                await transaction.RollbackAsync();
                throw;
            }

        }

        public async Task<EmployeeDTO?> UpdateEmployee(int id, EmployeeDTO employee)
        {
            var existingEmployee = await _commonRepo.GetByIdAsync(id);
            if (existingEmployee == null) return null;

            //map dto to entity
            existingEmployee.Name = employee.Name;
            existingEmployee.Department = employee.Department;
            existingEmployee.Position = employee.Position;
            existingEmployee.Email = employee.Email;

            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var result = await _commonRepo.UpdateAsync(existingEmployee);
                await _context.SaveChangesAsync(); // commit changes to DB

                // commit transaction
                await transaction.CommitAsync();

                // map entity back to dto
                return new EmployeeDTO
                {
                    EmployeeId = result.EmployeeId,
                    Name = result.Name,
                    Department = result.Department,
                    Position = result.Position,
                    Email = result.Email
                };
            }
            catch
            {
                // rollback if anything fails
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            var existingEmployee = await _commonRepo.GetByIdAsync(id);
            if (existingEmployee == null) return false;
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                await _commonRepo.DeleteAsync(id);
                await _context.SaveChangesAsync(); // commit changes to DB

                // commit transaction
                await transaction.CommitAsync();

                // map entity back to dto
                return true;
            }
            catch
            {
                // rollback if anything fails
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}

//todo: create mapper for dto and entity mapping