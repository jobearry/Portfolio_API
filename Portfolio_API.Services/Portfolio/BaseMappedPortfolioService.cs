using System;
using Portfolio_API.DataAccess.Contexts;
using Portfolio_API.DataTypes.Interfaces;
using Portfolio_API.Mapper;

namespace Portfolio_API.Services.Portfolio;

public class BaseMappedPortfolioService<TEntity, TDtoRead, TDtoCreate> : IMappedService<TEntity, TDtoRead, TDtoCreate>
  where TEntity : class
  where TDtoRead : class
  where TDtoCreate : class
{
  protected readonly IRepository<TEntity> _repository;
  protected readonly JDBContext _context;
  protected readonly IMapper<TEntity, TDtoRead, TDtoCreate> _mapper;
  public BaseMappedPortfolioService(IRepository<TEntity> repository, JDBContext context, IMapper<TEntity, TDtoRead, TDtoCreate> mapper)
  {
    _context = context;
    _repository = repository;
    _mapper = mapper;
  }
  
  public virtual async Task<List<TDtoRead>> GetAllAsync()
  {
    var entities = await _repository.GetAllAsync();
    if (entities is null) throw new KeyNotFoundException("Data not found");
    return entities.Select(e => _mapper.MapToDto(e)).ToList();
  }

  public virtual async Task<TDtoRead> GetByIdAsync(int id)
  {
    var entity = await _repository.GetByIdAsync(id);
    if (entity is null) throw new KeyNotFoundException();
    return _mapper.MapToDto(entity);
  }

  public virtual async Task AddNewItemAsync(TDtoCreate dto)
  {
    var newItem = _mapper.MapToEntity(dto);
    await _repository.AddNewItemAsync(newItem);
  }
}
