using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/v1/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly TnGContext _context;

        public UserController(TnGContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            return Ok(await _context.Users.ToListAsync());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<List<User>>> Get(int Id)
        {
            var us = await _context.Users.FindAsync(Id);
            if (us == null)
                return BadRequest("not thing.");
            return Ok(us);
        }

        [HttpPost]
        public async Task<ActionResult<List<User>>> Add(User us)
        {
            _context.Users.Add(us);
            await _context.SaveChangesAsync();

            return Ok(await _context.Users.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<User>>> Update(User request)
        {
            var us = await _context.Users.FindAsync(request.Id);
            if (us == null)
                return BadRequest("not thing.");

            us.Id = request.Id;
            us.Name = request.Name;
            us.Password = request.Password;
            us.Phone = request.Phone;
            us.Email = request.Email;
            us.Address = request.Address;
            us.TripId = request.TripId;

            await _context.SaveChangesAsync();

            return Ok(await _context.Users.ToListAsync());
        }


        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<User>>> Delete(int Id)
        {
            var us = await _context.Users.FindAsync(Id);
            if (us == null)
                return BadRequest("not thing.");

            _context.Users.Remove(us);
            await _context.SaveChangesAsync();

            return Ok(await _context.Users.ToListAsync());
        }
    }
}
