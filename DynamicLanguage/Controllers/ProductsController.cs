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
    public class ProductsController(AppDbContext _appDbContext) : ControllerBase
    {
      
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Product> products = await _appDbContext.Products.ToListAsync();
            List<ProductGetVM> productGetVMs = ObjectMapper.Mapper.Map<List<ProductGetVM>>(products);

            return Ok(productGetVMs);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductAddVM productAddVM)
        {
            Product product = ObjectMapper.Mapper.Map<Product>(productAddVM);

            await _appDbContext.AddAsync(product);

            await _appDbContext.SaveChangesAsync();

            return Created("/Products", product);
        }
    }
}
