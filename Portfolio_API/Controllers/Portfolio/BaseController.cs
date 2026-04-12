using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio_API.DataTypes.Interfaces;

namespace Portfolio_API.Controllers.Portfolio
{
     public abstract class BaseController<TEntity> : ControllerBase
        where TEntity : class
    {
        protected readonly IService<TEntity> _baseService;
        protected BaseController(IService<TEntity> baseService)
        {
            _baseService = baseService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TEntity>>> GetAll()
        {
            var items = await _baseService.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> GetById(int id)
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
    }
}