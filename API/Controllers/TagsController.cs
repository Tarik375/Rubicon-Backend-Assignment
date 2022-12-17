using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{   
    [ApiController]
    [Route("api/[controller]")]
    
    public class TagsController : ControllerBase
    {
        private readonly DataContext _context;
        public TagsController(DataContext context)
        {
            _context = context;    
        }
     [HttpGet]
     public async Task<ActionResult<IEnumerable<Tag>>> GetTags()
     {
        return await _context.Tags.ToListAsync();
     }
        
    }
}