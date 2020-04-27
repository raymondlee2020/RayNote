using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RayNote.DataAccessLayer;
using RayNote.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;

namespace RayNote.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoteController : ControllerBase
    {
        private readonly RayNoteDbContext _dbContext;
        private readonly string secret = "GQDstcKsx0NHjPOuXOYg5MbeJ1XT0uFiwDVvVBrk";
        private SHA256 sha256;
        private IJwtEncoder jwtEncoder;
        private IJwtDecoder jwtDecoder;

        public NoteController(RayNoteDbContext dbContext)
        {
            _dbContext = dbContext;

            sha256 = SHA256.Create();

            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            jwtEncoder = new JwtEncoder(algorithm, serializer, urlEncoder);

            var provider = new UtcDateTimeProvider();
            IJwtValidator validator = new JwtValidator(serializer, provider);
            jwtDecoder = new JwtDecoder(serializer, validator, urlEncoder, algorithm);
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
                TextWriter errorWriter = Console.Error;
                errorWriter.WriteLine(e.Message);
                return BadRequest();
            }
        }

        [HttpGet("owner/{id}")]
        public IActionResult GetByOwnerId(int id, [FromQuery]string token)
        {
            try
            {
                var json = jwtDecoder.Decode(token, secret, verify: true);
                Console.WriteLine(json);
                return new JsonResult(_dbContext.Note.Where(note => note.OwnerId == id).ToList());
            }
            catch (TokenExpiredException)
            {
                Console.WriteLine("Token has expired");
                return BadRequest();
            }
            catch (SignatureVerificationException)
            {
                Console.WriteLine("Token has invalid signature");
                return BadRequest();
            }
            catch (Exception e)
            {
                TextWriter errorWriter = Console.Error;
                errorWriter.WriteLine(e.Message);
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
                TextWriter errorWriter = Console.Error;
                errorWriter.WriteLine(e.Message);
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
                TextWriter errorWriter = Console.Error;
                errorWriter.WriteLine(e.Message);
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
                TextWriter errorWriter = Console.Error;
                errorWriter.WriteLine(e.Message);
                return BadRequest();
            }
        }
    }
}
