using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RayNote.DataAccessLayer;
using RayNote.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using System.Text;
using System.IO;

namespace RayNote.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly RayNoteDbContext _dbContext;
        private readonly string secret = "GQDstcKsx0NHjPOuXOYg5MbeJ1XT0uFiwDVvVBrk";
        private SHA256 sha256;
        private IJwtEncoder jwtEncoder;
        private IJwtDecoder jwtDecoder;

        public UserController(RayNoteDbContext dbContext)
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
                return new JsonResult(_dbContext.User.Single(user => user.Id == id));
            }
            catch (Exception e)
            {
                TextWriter errorWriter = Console.Error;
                errorWriter.WriteLine(e.Message);
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]User entity)
        {
            try
            {
                Console.WriteLine("POST");
                entity.Password = GetHash(sha256, entity.Password);
                var hasData = _dbContext.User.Where(user => (user.Account == entity.Account && user.Password == entity.Password)).ToList();
                if (hasData.Count == 0)
                {
                    _dbContext.User.Add(entity);
                    _dbContext.SaveChanges();
                    return Get(entity.Id);
                }
                else
                {
                    ErrorModel error = new ErrorModel();
                    error.Message = "Sign Up Failed.";
                    return new JsonResult(error);
                }
            }
            catch (Exception e)
            {
                TextWriter errorWriter = Console.Error;
                errorWriter.WriteLine(e.Message);
                return BadRequest();
            }
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody]LoginModel entity)
        {
            try
            {
                Console.WriteLine("login");
                var vUser = _dbContext.User.Single(user => (user.Account == entity.Account && user.Password == GetHash(sha256, entity.Password)));
                if (vUser != null)
                {
                    var data = new Dictionary<string, object>
                    {
                        { "id", vUser.Id }
                    };
                    var token = jwtEncoder.Encode(data, secret);
                    var result = new ClientModel();
                    result.Id = vUser.Id;
                    result.Name = vUser.Name;
                    result.Token = token;
                    return new JsonResult(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception e)
            {
                TextWriter errorWriter = Console.Error;
                errorWriter.WriteLine(e.Message);
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
                TextWriter errorWriter = Console.Error;
                errorWriter.WriteLine(e.Message);
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
                TextWriter errorWriter = Console.Error;
                errorWriter.WriteLine(e.Message);
                return BadRequest();
            }
        }

        private static string GetHash(HashAlgorithm hashAlgorithm, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            var sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        private static bool VerifyHash(HashAlgorithm hashAlgorithm, string input, string hash)
        {
            // Hash the input.
            var hashOfInput = GetHash(hashAlgorithm, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            return comparer.Compare(hashOfInput, hash) == 0;
        }
    }
}
