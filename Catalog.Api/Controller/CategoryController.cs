using Catalog.Application.DTOs;
using Catalog.Application.Interface;
using Catalog.Domain.Entities;
using Microsoft.AspNetCore.Mvc;


namespace Catalog.Api.Controller
{
    [Route("api/v1/[Controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            try
            {
                var category = await _categoryService.GetCategories();
                return Ok(category);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet("{id}", Name = "GetCategory")]
        public async Task<ActionResult<Category>> Get(int id)
        {
            var category = await _categoryService.GetById(id);

            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoryDTO categoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _categoryService.Add(categoryDto);

            return new CreatedAtRouteResult("GetCategoria",
                new { id = categoryDto.Id }, categoryDto);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] CategoryDTO categoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != categoryDto.Id)
            {
                return BadRequest();
            }
            await _categoryService.Update(categoryDto);
            return Ok(categoryDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> Delete(int id)
        {
            var categoryDto = await _categoryService.GetById(id);
            if (categoryDto == null)
            {
                return NotFound();
            }
            await _categoryService.Remove(id);
            return Ok(categoryDto);
        }
    }
}