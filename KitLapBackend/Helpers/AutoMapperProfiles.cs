using AutoMapper;
using KitLapBackend.DTOs;
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
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.DiscountedPrice, opt => opt.MapFrom(src => src.HasDiscount ? (1 - (src.DiscountRate / 100)) * src.Price : 0))
                .ForMember(dest => dest.RatingStats, opt => opt.MapFrom(src => 
                new RatingsStatsDto{ RatingsAverage = src.Rating.Average(val => val.Value), RatingsCount = src.Rating.Count()}));
        }
    }
}
