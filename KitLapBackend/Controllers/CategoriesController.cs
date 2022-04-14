using AutoMapper;
using AutoMapper.QueryableExtensions;
using KitLapBackend.Data;
using KitLapBackend.DTOs.Requests;
using KitLapBackend.DTOs.Responses;
using KitLapBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitLapBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : BaseController
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CategoriesController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost, Route("AddCategory")]
        public async Task<ActionResult> AddCategory(AddCategoryDto addCategoryDto)
        {
            var product = await _context.Products.Include(p => p.Categories).FirstOrDefaultAsync(product => product.Id == addCategoryDto.ProductId);
            if (product == null)
                return NotFound("Cannot find the associated Product.");

            product.Categories.Add(
                new Category
                {
                    CategoryName = addCategoryDto.CategoryName
                }
                );

            await _context.SaveChangesAsync();

            return Created("", _context.Products.ProjectTo<ProductSummaryDto>(_mapper.ConfigurationProvider).FirstOrDefault(id => id.Id == addCategoryDto.ProductId));
        }

        [HttpPost, Route("GetCategories")]
        public ActionResult<List<CategoryDto>> GetCategories([FromBody] int ProductId)
        {
            var categories = _context.Categories.Where(p => p.ProductId == ProductId).ProjectTo<CategoryDto>(_mapper.ConfigurationProvider);
            return Ok(categories);
        }

        [HttpPost, Route("UpdateCategory")]
        public async Task<ActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(category => category.Id == updateCategoryDto.CategoryId);
            if (category == null)
                return NotFound("Category Not Found.");

            category.CategoryName = updateCategoryDto.CategoryName;

            _context.Categories.Update(category);

            await _context.SaveChangesAsync();

            return Ok("Category Updated Successfully!");
        }

        [HttpDelete, Route("DeleteCategory")]
        public async Task<ActionResult> DeleteCategory(DeleteCategoryDto deleteCategoryDto)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(category => category.Id == deleteCategoryDto.CategoryId);
            if (category == null)
                return NotFound("Category Not Found.");

            _context.Categories.Remove(category);

            await _context.SaveChangesAsync();

            return Ok("Category deleted successfully");
        }

        [HttpDelete, Route("DeleteProductCategories")]
        public async Task<ActionResult> DeleteProductCategory(DeleteProductCategoriesDto deleteCategoriesDto)
        {
            var product = await _context.Products.FirstOrDefaultAsync(product => product.Id == deleteCategoriesDto.ProductId);
            if (product == null)
                return NotFound("Product Not Found.");

            _context.Categories.RemoveRange(product.Categories);

            await _context.SaveChangesAsync();

            return Ok("Categories deleted successfully");
        }

        [HttpDelete, Route("DeleteAllCategories")]
        public async Task<ActionResult> DeleteAllCategories()
        {
            if (!await _context.Categories.AnyAsync())
                return NotFound("No Categories Exist");

            _context.Categories.RemoveRange(await _context.Categories.ToListAsync());

            await _context.SaveChangesAsync();

            return Ok("Categories Deleted Successfully!");
        }
    }
}
