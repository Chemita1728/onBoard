using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using onBoard.Data;
using onBoard.Models;

namespace onBoard.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class HourController : ControllerBase
    {

        private readonly ProjectContext _context;

        private readonly ILogger<HourController> _logger;

        public HourController(ILogger<HourController> logger, ProjectContext context)
        {
            _logger = logger;
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet(Name = "GetHour")]
        public IEnumerable<HourSQL> Get( int offset = 0, int limit = 10 )
        {
            
            return _context.Hours.AsNoTracking().Skip(offset).Take(limit); 
        }
    }
}

