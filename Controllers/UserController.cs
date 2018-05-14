using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System;
using System.Text.RegularExpressions;
using System.Net.Mail;
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
        
        [HttpPost("create")]
        public IActionResult Create([FromBody] User user)
        {
            RequestHelper response = new RequestHelper();
            Dictionary<string, object> responseBody = user.ValidateUser(user);

            if(responseBody.Count()>0) return response.BadRequest(responseBody);

            user.Email = user.Email.ToLower();

            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }
            catch(Exception)
            {
                return BadRequest("Failed to create User.");
            }
            
            return response.Success(user);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User userPayLoad)
        {
            RequestHelper response = new RequestHelper();
            
            if(userPayLoad == null)
            {
                return response.BadRequest(null);
            }

            userPayLoad.Email = userPayLoad.Email.ToLower();
            User user = GetAll().Where(u => u.Email == userPayLoad.Email).FirstOrDefault();

            if(user == null)
            {
                return response.NotFound();
            }
            else if(user.Password == userPayLoad.Password)
            {
                return response.Success(user);
            }
            else
            {
                return response.Unauthorized();
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