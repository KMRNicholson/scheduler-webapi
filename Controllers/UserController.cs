using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using SchedulerWebApi.Models;

namespace SchedulerWebApi.Controllers
{
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly UserContext _context;

        public UserController(UserContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }    

        [HttpGet("{id}", Name = "GetUser")]
        public ActionResult GetById(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        
        [HttpPost]
        public IActionResult Create([FromBody] User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return CreatedAtRoute("GetUser", new { id = user.Id }, user);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User userPayLoad)
        {
            if(userPayLoad == null)
            {
                return BadRequest();
            }

            User user = GetAll().Where(u => u.Email == userPayLoad.Email).FirstOrDefault();

            if(user == null)
            {
                return NotFound();
            }
            else if(user.Password == userPayLoad.Password)
            {
                return Ok(user);
            }
            else
            {
                return Unauthorized();
            }
        }    

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] User updated)
        {
            if (updated == null)
            {
                return BadRequest();
            }
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            user.Password = updated.Password;
            user.Email = updated.Email;

            _context.Users.Update(user);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            _context.SaveChanges();
            return NoContent();
        } 
    }
}