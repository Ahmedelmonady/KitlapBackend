using AutoMapper;
using KitLapBackend.DTOs.Responses;
using KitLapBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitLapBackend.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            //Mapping Product to ProductDto showing RatingsStats
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.DiscountedPrice, opt => opt.MapFrom(src => src.HasDiscount ? (1 - (src.DiscountRate / 100)) * src.Price : 0))
                .ForMember(dest => dest.RatingStats, opt => opt.MapFrom(src => 
                new RatingsStatsDto{ RatingsAverage = (float)src.Ratings.Average(val => val.Value), RatingsCount = src.Ratings.Count }))
                .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.Categories));
            
            //Mapping Ratings to RatingsDto showing Values
            CreateMap<Rating, CategoriesDto>();

            //Mapping Categories to CateogriesDto showing Values
            CreateMap<Category, CategoryDto>();
        }
    }
}
