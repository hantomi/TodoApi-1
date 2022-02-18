using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            return Ok(await _context.user.ToListAsync());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<List<User>>> Get(int Id)
        {
            var us = await _context.user.FindAsync(Id);
            if (us == null)
                return BadRequest("not thing.");
            return Ok(us);
        }

        [HttpPost]
        public async Task<ActionResult<List<User>>> Add(User us)
        {
            _context.user.Add(us);
            await _context.SaveChangesAsync();

            return Ok(await _context.user.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<User>>> Update(User request)
        {
            var us = await _context.user.FindAsync(request.Id);
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

            return Ok(await _context.user.ToListAsync());
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<User>>> Delete(int Id)
        {
            var us = await _context.user.FindAsync(Id);
            if (us == null)
                return BadRequest("not thing.");

            _context.user.Remove(us);
            await _context.SaveChangesAsync();

            return Ok(await _context.user.ToListAsync());
        }
    }
}
