#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using TodoApi.IRepository;
using TodoApi.Repository;

namespace TodoApi.Controllers
{
    [Route("api/v1/bicycle-histories")]
    [ApiController]
    public class BicycleHistoriesController : ControllerBase
    {
        private readonly TnGContext _context;
        private IBicycleHistoryRepository bHistoryRepo;
        public BicycleHistoriesController(TnGContext context)
        {
            this.bHistoryRepo = new BicycleHistoryRepository(context);
            _context = context;
        }

        // GET: api/BicycleHistories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BicycleHistory>>> GetBicycleHistories()
        {
            return await _context.BicycleHistories.ToListAsync();
        }

        // GET: api/BicycleHistories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BicycleHistory>> GetBicycleHistory(int id)
        {
            var bicycleHistory = await _context.BicycleHistories.FindAsync(id);

            if (bicycleHistory == null)
            {
                return NotFound();
            }

            return bicycleHistory;
        }

        // PUT: api/BicycleHistories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBicycleHistory(int id, BicycleHistory bicycleHistory)
        {
            if (id != bicycleHistory.Id)
            {
                return BadRequest();
            }

            _context.Entry(bicycleHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BicycleHistoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BicycleHistories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BicycleHistory>> PostBicycleHistory(BicycleHistory bicycleHistory)
        {
            _context.BicycleHistories.Add(bicycleHistory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BicycleHistoryExists(bicycleHistory.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBicycleHistory", new { id = bicycleHistory.Id }, bicycleHistory);
        }

        // DELETE: api/BicycleHistories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBicycleHistory(int id)
        {
            var bicycleHistory = await _context.BicycleHistories.FindAsync(id);
            if (bicycleHistory == null)
            {
                return NotFound();
            }

            _context.BicycleHistories.Remove(bicycleHistory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BicycleHistoryExists(int id)
        {
            return _context.BicycleHistories.Any(e => e.Id == id);
        }
    }
}
