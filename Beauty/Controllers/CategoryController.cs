using Beauty.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Beauty.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CustomContext _context;

        public CategoryController(CustomContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult Create(DtoCategory dtocat)
        {
            Category cat = new Category();
            cat.Create(_context, dtocat);
            _context.SaveChanges();
            return Ok();
        }
    }
}
