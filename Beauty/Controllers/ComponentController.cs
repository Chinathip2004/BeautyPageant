using Beauty.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace Beauty.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComponentController : ControllerBase
    {
        private readonly CustomContext _context;

        public ComponentController(CustomContext context)
        {
            _context = context;
        }
        //[HttpGet]
        [HttpPost]
        public ActionResult Create([FromBody] string Hello)
        {
                
            Event ev = JsonConvert.DeserializeObject<Event>(Hello);
            
            ev.Create(_context);
            _context.SaveChanges();
            

            return Ok();
        }

        [HttpGet("GetById")]
        public ActionResult GetById(int? id)
        {
            var ev = _context.Events.Where(w => w.Id == id).First();
            ev.Dependents = _context.Dependents.Where(d => d.EventId == id).ToList();


            foreach (var e in ev.Dependents)
            {

                e.com = _context.Components.Where(c => c.Id == e.PageId).FirstOrDefault();
                e.com.Containings = _context.Containings.Where(c => c.ContainerId == e.PageId).ToList();
                foreach(var c in e.com.Containings)
                {
                    
                    c.GetById(_context, e.com);
                }

                //e.Page = _context.Pages.Where(p => p.Id == e.PageId).FirstOrDefault();
                //if (e.Page != null)
                //{
                //    //e.Page.Id = (int)e.Page.PageId;
                //    e.Page.Id = e.Page.Id;



                //    //e.Page.Containings = _context.Containings.Where(c => c.ContainerId == e.Page.PageId).ToList();

                //    //foreach (var c in e.Page.Containings)
                //    //{

                //    //    c.Component = _context.Components.Where(cm => cm.Id == c.ComponentId).FirstOrDefault();

                //    //    foreach(var d in c.Component.Containings)
                //    //    {
                            
                //    //    }
                        
                //    //}

                //}

            }

            return Ok(ev);
        }

        [HttpGet("GetAll")]
        public ActionResult GetAll()
        {

            return Ok("Hello World I need help!!");
        }

    }
}
