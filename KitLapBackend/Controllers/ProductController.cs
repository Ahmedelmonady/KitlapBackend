using AutoMapper;
using AutoMapper.QueryableExtensions;
using KitLapBackend.Data;
using KitLapBackend.DTOs;
using KitLapBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitLapBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ProductController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
