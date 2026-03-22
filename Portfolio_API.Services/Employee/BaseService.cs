using Microsoft.EntityFrameworkCore;
using Portfolio_API.DataAccess.Contexts;
using Portfolio_API.Mapper;
using Portfolio_API.DataTypes.Models.EmployeeManagementModels;
using Portfolio_API.DataAccess.Repositories;
using Portfolio_API.DataAccess.Repositories.EmployeeManagementRepository;

namespace Portfolio_API.Services.Employee
{
    public interface IEmployeeBaseService<TEntity, TDto> 
        where TEntity : class
        where TDto : class
    {
        Task<List<TDto>> GetAllAsync();
        Task<TDto> GetByIdAsync(int id);
        Task AddAsync(TDto dto);
        Task Update(int id, TDto dto);
        Task Delete(int id);
    }
    public class EmployeeBaseService<TEntity, TDto> : IEmployeeBaseService<TEntity, TDto> 
        where TEntity : class
        where TDto : class
    {
        private readonly IEmployeeBaseRepository<TEntity> _repository;
        private readonly EmployeeDbContext _employeeDBContext;
        private readonly IMapper<TEntity, TDto> _mapper;
        public EmployeeBaseService(IEmployeeBaseRepository<TEntity> repository, IMapper<TEntity, TDto> mapper, EmployeeDbContext employeeDBContext)
        {
            _repository = repository;
            _employeeDBContext = employeeDBContext;
            _mapper = mapper;
        }

        public virtual async Task<List<TDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Select(e => _mapper.MapToDto(e)).ToList();
        }

        public virtual async Task<TDto> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new KeyNotFoundException();
            }
            return _mapper.MapToDto(entity);
        }

        public virtual async Task AddAsync(TDto dto)
        {
            var entity = _mapper.MapToEntity(dto);
            await _repository.AddAsync(entity);
            await _employeeDBContext.SaveChangesAsync();
        }
        public virtual async Task Update(int id, TDto dto) 
        {
            var existingEntity = await _repository.GetByIdAsync(id);
            if (existingEntity == null) throw new KeyNotFoundException();

            _mapper.UpdateEntity(existingEntity, dto);
            _repository.Update(existingEntity);
            await _employeeDBContext.SaveChangesAsync();
        }
        public virtual async Task Delete(int id)
        {
            var existingEntity = await _repository.GetByIdAsync(id);
            if (existingEntity == null) throw new KeyNotFoundException();
         
            _repository.Delete(existingEntity);
            await _employeeDBContext.SaveChangesAsync();
        }

    }
}
