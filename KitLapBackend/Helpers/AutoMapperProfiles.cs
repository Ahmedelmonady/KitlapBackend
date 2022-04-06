using AutoMapper;
using KitLapBackend.DTOs.Responses;
using KitLapBackend.Models;
using System.Linq;

namespace KitLapBackend.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            //Mapping Product to ProductDto showing RatingsStats
            CreateMap<Product, ProductSummaryDto>()
                .ForMember(dest => dest.DiscountedPrice, opt => opt.MapFrom(src => src.HasDiscount ? (1 - (src.DiscountRate / 100)) * src.Price : 0))
                .ForMember(dest => dest.RatingStats, opt => opt.MapFrom(src =>
                new RatingsStatsDto { RatingsAverage = src.Ratings.Count > 0 ? (float)src.Ratings.Average(val => val.Value) : 0, RatingsCount = src.Ratings.Count }));

            //Mapping Product to ProductDto showing RatingsStats
            CreateMap<Product, ProductDetailsDto>()
                .ForMember(dest => dest.DiscountedPrice, opt => opt.MapFrom(src => src.HasDiscount ? (1 - (src.DiscountRate / 100)) * src.Price : 0));
            
            //Mapping Ratings to RatingsDto showing Values
            CreateMap<Rating, RatingsDto>();

            //Mapping Categories to CateogriesDto showing Values
            CreateMap<Category, CategoryDto>();

            CreateMap<ProductSummaryDto, Product>();
        }
    }
}
