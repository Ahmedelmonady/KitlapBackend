using AutoMapper;
using KitLapBackend.Data;
using Microsoft.AspNetCore.Mvc;

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
    }
}
