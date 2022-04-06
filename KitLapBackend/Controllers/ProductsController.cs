using AutoMapper;
using AutoMapper.QueryableExtensions;
using KitLapBackend.Data;
using KitLapBackend.DTOs.Requests;
using KitLapBackend.DTOs.Responses;
using KitLapBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KitLapBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ProductsController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost, Route("AddProduct")]
        public async Task<ActionResult> AddProduct(AddProductDto productDto)
        {
            if (productDto.HasDiscount && productDto.DiscountRate == 0)
                return BadRequest("Discount Rate MUST be set");

            await _context.Products.AddAsync(
                new Product
                {
                    Title = productDto.Title,
                    Description = productDto.Description,
                    ImageUrl = productDto.ImageUrl,
                    Price = productDto.Price,
                    HasDiscount = productDto.HasDiscount,
                    DiscountRate = productDto.DiscountRate,
                    Ratings = new List<Rating>(),
                    Categories = new List<Category>()
                }
                );

            await _context.SaveChangesAsync();

            return Ok("Product Created Successfully");
        }

        [HttpPost, Route("UpdateProduct")]
        public async Task<ActionResult> UpdateProduct(UpdateProductDto productDto)
        {
            var product = await _context.Products.FirstOrDefaultAsync(product => product.Id == productDto.ProductId);
            if (product == null)
                return NotFound("No such Product Exists");

            product.Title = productDto.Title;
            product.Description = productDto.Description;
            product.ImageUrl = productDto.ImageUrl;
            product.Price = productDto.Price;
            product.HasDiscount = productDto.HasDiscount;
            product.DiscountRate = productDto.DiscountRate;

            _context.Products.Update(product);

            await _context.SaveChangesAsync();

            return Ok("Product Updated Successfully");
        }

        [HttpPost, Route("GetProductSummary")]
        public async Task<ActionResult<ProductSummaryDto>> GetProductSummary(GetProductDto productDto)
        {
            var product = await _context.Products.Include(c => c.Categories).Include(r => r.Ratings).ProjectTo<ProductSummaryDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(product => product.Id == productDto.ProductId);
            if (product == null)
                return NotFound("No such Product Exists");

            return Ok(product);
        }

        [HttpPost, Route("GetProductDetails")]
        public async Task<ActionResult<ProductDetailsDto>> GetProductDetails(GetProductDto productDto)
        {
            var product = await _context.Products.Include(c => c.Categories).Include(r => r.Ratings).ProjectTo<ProductDetailsDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(product => product.Id == productDto.ProductId);
            if (product == null)
                return NotFound("No such Product Exists");

            return Ok(product);
        }

        [HttpGet, Route("GetAllProductsSummary")]
        public async Task<ActionResult<List<ProductSummaryDto>>> GetAllProductsSummary()
        {
            if (!await _context.Products.AnyAsync())
                return NotFound("No Products Exist");
            
            var products = await _context.Products.Include(c => c.Categories).Include(r => r.Ratings).ProjectTo<ProductSummaryDto>(_mapper.ConfigurationProvider).ToListAsync();
            

            return Ok(products);
        }

        [HttpGet, Route("GetAllProductsDetails")]
        public async Task<ActionResult<ProductDetailsDto>> GetAllProductsDetails()
        {
            if (!await _context.Products.AnyAsync())
                return NotFound("No Products Exist");

            var products = await _context.Products.Include(c => c.Categories).Include(r => r.Ratings).ProjectTo<ProductDetailsDto>(_mapper.ConfigurationProvider).ToListAsync();


            return Ok(products);
        }

        [HttpDelete, Route("DeleteProduct")]
        public async Task<ActionResult> DeleteProduct(DeleteProductDto productDto)
        {
            var product = await _context.Products.FirstOrDefaultAsync(product => product.Id == productDto.ProductId);

            if (product == null)
                return NotFound("Product Not found");

            _context.Products.Remove(product);

            await _context.SaveChangesAsync();

            return Ok("Product Deleted Successfully!");
        }
    }
}
