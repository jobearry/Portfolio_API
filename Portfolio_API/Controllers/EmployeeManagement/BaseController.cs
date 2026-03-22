using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio_API.DataTypes.Models.EmployeeManagementModels;
using Portfolio_API.Services;
using Portfolio_API.Services.Employee;

namespace Portfolio_API.Controllers.EmployeeManagement
{
    public abstract class BaseController<TEntity, TDto> : ControllerBase
        where TEntity : class
        where TDto : class
    {
        protected readonly IEmployeeBaseService<TEntity, TDto> _baseService;
        protected BaseController(IEmployeeBaseService<TEntity, TDto> baseService)
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

        [HttpPost]
        public async Task<ActionResult<TDto>> Add(TDto entity)
        {
            await _baseService.AddAsync(entity);
            return CreatedAtAction(nameof(Add), entity);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TDto>> Update(int id, TDto entity)
        {
            try
            {
                await _baseService.Update(id, entity);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Data with Id {id} not found");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _baseService.Delete(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Data with Id {id} not found");
            }
        }
    }
}
