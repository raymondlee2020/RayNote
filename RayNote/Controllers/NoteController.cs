using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RayNote.DataAccessLayer;
using RayNote.Models;
using Microsoft.AspNetCore.Mvc;

namespace RayNote.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoteController : ControllerBase
    {
        private readonly RayNoteDbContext _dbContext;

        public NoteController(RayNoteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return new JsonResult(_dbContext.Note.Single(note => note.Id == id));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return BadRequest();
            }
        }

        [HttpGet("owner/{id}")]
        public IActionResult GetByOwnerId(int id)
        {
            try
            {
                return new JsonResult(_dbContext.Note.Where(note => note.OwnerId == id).ToList());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]Note entity)
        {
            try
            {
                Console.WriteLine(entity);
                _dbContext.Note.Add(entity);
                _dbContext.SaveChanges();
                Console.WriteLine(entity);
                return Get(entity.Id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult PutById([FromRoute]int id, [FromBody]Note entity)
        {
            try
            {
                var oriNote = _dbContext.Note.SingleOrDefault(note => note.Id == id);
                if (oriNote != null)
                {
                    entity.Id = id;
                    _dbContext.Entry(oriNote).CurrentValues.SetValues(entity);
                    _dbContext.SaveChanges();
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById([FromRoute]int id)
        {
            try
            {
                var oriNote = _dbContext.Note.SingleOrDefault(note => note.Id == id);
                if (oriNote != null)
                {
                    _dbContext.Note.Remove(oriNote);
                    _dbContext.SaveChanges();
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return BadRequest();
            }
        }
    }
}
