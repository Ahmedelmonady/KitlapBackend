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
    public class RatingsController : BaseController
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public RatingsController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost, Route("AddRating")]
        public async Task<ActionResult> AddRating(AddRatingDto ratingsDto)
        {
            var product = await _context.Products.Include(r => r.Ratings).FirstOrDefaultAsync(product => product.Id == ratingsDto.ProductId);
            if (product == null)
                return NotFound("Cannot find the associated Product.");

            product.Ratings.Add(
                new Rating
                {
                    Value = ratingsDto.RatingValue
                }
                );

            await _context.SaveChangesAsync();

            return Created("", _context.Products.ProjectTo<ProductSummaryDto>(_mapper.ConfigurationProvider).FirstOrDefault(id => id.Id == ratingsDto.ProductId));
        }

        [HttpPost, Route("GetRatings")]
        public ActionResult<List<RatingsDto>> GetRatings([FromBody]int ProductId)
        {
            var ratings = _context.Ratings.Where(p => p.ProductId == ProductId).ProjectTo<RatingsDto>(_mapper.ConfigurationProvider);
            return Ok(ratings);
        }

        [HttpPost, Route("UpdateRating")]
        public async Task<ActionResult> UpdateRating(UpdateRatingDto ratingsDto)
        {
            var rating = await _context.Ratings.FirstOrDefaultAsync(rating => rating.Id == ratingsDto.RatingId);
            if (rating == null)
                return NotFound("Rating Not Found.");

            rating.Value = ratingsDto.RatingValue;

            _context.Ratings.Update(rating);

            await _context.SaveChangesAsync();

            return Ok("Rating Updated Successfully!");
        }

        [HttpDelete, Route("DeleteRating")]
        public async Task<ActionResult> DeleteRating(DeleteRatingDto deleteRatingDto)
        {
            var rating = await _context.Ratings.FirstOrDefaultAsync(rating => rating.Id == deleteRatingDto.RatingId);
            if (rating == null)
                return NotFound("Rating Not Found.");

            _context.Ratings.Remove(rating);

            await _context.SaveChangesAsync();

            return Ok("Rating deleted successfully");
        }

        [HttpDelete, Route("DeleteProductRatings")]
        public async Task<ActionResult> DeleteProductRating(DeleteProductRatingsDto deleteRatingsDto)
        {
            var product = await _context.Products.FirstOrDefaultAsync(product => product.Id == deleteRatingsDto.ProductId);
            if (product == null)
                return NotFound("Product Not Found.");

            _context.Ratings.RemoveRange(product.Ratings);

            await _context.SaveChangesAsync();

            return Ok("Ratings deleted successfully");
        }
    }
}
