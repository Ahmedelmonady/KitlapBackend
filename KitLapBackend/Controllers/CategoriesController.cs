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
        public async Task<ActionResult> AddCategory(AddCategoryDto categoriesDto)
        {
            var product = await _context.Products.Include(p => p.Categories).FirstOrDefaultAsync(product => product.Id == categoriesDto.ProductId);
            if (product == null)
                return NotFound("Cannot find the associated Product.");

            product.Categories.Add(
                new Category
                {
                    CategoryName = categoriesDto.CategoryName
                }
                );

            await _context.SaveChangesAsync();

            return Created("", _context.Products.ProjectTo<ProductDto>(_mapper.ConfigurationProvider).FirstOrDefault(id => id.Id == categoriesDto.ProductId));
        }

        [HttpPost, Route("GetCategories")]
        public ActionResult<List<CategoriesDto>> GetRatings([FromBody] int ProductId)
        {
            var categories = _context.Ratings.Where(p => p.ProductId == ProductId).ProjectTo<CategoriesDto>(_mapper.ConfigurationProvider);
            return Ok(categories);
        }

        [HttpPost, Route("UpdateCategory")]
        public async Task<ActionResult> UpdateRating(UpdateCategoryDto categoryDto)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(rating => rating.Id == categoryDto.RatingId);
            if (category == null)
                return NotFound("Category Not Found.");

            category.CategoryName = categoryDto.CategoryName;

            _context.Categories.Update(category);

            await _context.SaveChangesAsync();

            return Ok("Category Updated Successfully!");
        }
    }
}
