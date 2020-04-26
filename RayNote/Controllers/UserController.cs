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
    public class UserController : ControllerBase
    {
        private readonly RayNoteDbContext _dbContext;

        public UserController(RayNoteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return new JsonResult(_dbContext.User.Single(user => user.Id == id));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]User entity)
        {
            try
            {
                _dbContext.User.Add(entity);
                _dbContext.SaveChanges();
                return Get(entity.Id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute]int id, [FromBody]User entity)
        {
            try
            {
                var oriUser = _dbContext.User.SingleOrDefault(user => user.Id == id);
                if (oriUser != null)
                {
                    entity.Id = id;
                    _dbContext.Entry(oriUser).CurrentValues.SetValues(entity);
                    _dbContext.SaveChanges();
                    return Get(entity.Id);
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
        public IActionResult Delete([FromRoute]int id)
        {
            try
            {
                var oriUser = _dbContext.User.SingleOrDefault(user => user.Id == id);
                if (oriUser != null)
                {
                    _dbContext.User.Remove(oriUser);
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
