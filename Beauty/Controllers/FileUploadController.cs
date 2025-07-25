using Beauty.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Beauty.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly CustomContext _context;

        public FileUploadController (CustomContext context)
        {
            _context = context; 
        }

        [HttpPost]
        public ActionResult Create([FromForm]DtoFile dto)
        {
            FileImg file = new FileImg();
            file.Create(_context, dto);
            
            return Ok();
        }
    }
}
