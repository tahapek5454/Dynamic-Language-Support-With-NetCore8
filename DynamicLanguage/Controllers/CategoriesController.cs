using DynamicLanguage.Context;
using DynamicLanguage.Mapper;
using DynamicLanguage.Models;
using DynamicLanguage.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DynamicLanguage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(AppDbContext _appDbContext) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Category> categories = await _appDbContext.Categories.ToListAsync();
            List<CategoryGetVM> categoryGetVMs = ObjectMapper.Mapper.Map<List<CategoryGetVM>>(categories);

            return Ok(categoryGetVMs);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoryAddVM categoryAddVM)
        {
            Category category = ObjectMapper.Mapper.Map<Category>(categoryAddVM);

            await _appDbContext.AddAsync(category);

            await _appDbContext.SaveChangesAsync();

            return Created("/Categories", category);
        }
    }
}
