using System;
using Portfolio_API.DataAccess.Contexts;
using Portfolio_API.DataTypes.Interfaces;
using Portfolio_API.Mapper;

namespace Portfolio_API.Services.Portfolio;

public class BaseMappedPortfolioService<TEntity, TDto> : IMappedService<TEntity, TDto>
  where TEntity : class
  where TDto : class
{
  private readonly IRepository<TEntity> _repository;
  private readonly JDBContext _context;
  private readonly IMapper<TEntity, TDto> _mapper;
  public BaseMappedPortfolioService(IRepository<TEntity> repository, JDBContext context, IMapper<TEntity, TDto> mapper)
  {
    _context = context;
    _repository = repository;
    _mapper = mapper;
  }
  
  public virtual async Task<List<TDto>> GetAllAsync()
  {
    var entities = await _repository.GetAllAsync();
    if (entities is null) throw new KeyNotFoundException("Data not found");
    return entities.Select(e => _mapper.MapToDto(e)).ToList();
  }

  public virtual async Task<TDto> GetByIdAsync(int id)
  {
    var entity = await _repository.GetByIdAsync(id);
    if (entity is null) throw new KeyNotFoundException();
    return _mapper.MapToDto(entity);
  }

  public virtual async Task AddNewItemAsync(TDto dto)
  {
    var newItem = _mapper.MapToEntity(dto);
    await _repository.AddNewItemAsync(newItem);
  }
}
