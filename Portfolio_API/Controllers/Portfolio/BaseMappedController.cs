using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio_API.DataTypes.Interfaces;

namespace Portfolio_API.Controllers.Portfolio
{
    public abstract class BaseMappedController<TEntity, TDto> : ControllerBase
        where TEntity : class
        where TDto : class
    {
        protected readonly IMappedService<TEntity, TDto> _baseService;
        protected BaseMappedController(IMappedService<TEntity, TDto> baseService)
        {
            _baseService = baseService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TDto>>> GetAll()
        {
            var items = await _baseService.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TDto>> GetById(int id)
        {
            try
            {
                var item = await _baseService.GetByIdAsync(id);
                return Ok(item);
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Data with Id {id} not found");
            }
        }
        [HttpPost("new")]
        public async Task<ActionResult<TDto>> AddNewItem([FromBody] TDto newEntity)
        {
            try
            {
                await _baseService.AddNewItemAsync(newEntity);
                return Created(
                    nameof(GetById),
                    newEntity
                );
            }
            catch (DbUpdateException dbex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, dbex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
