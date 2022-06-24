using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectTestSem3_Server.Data;
using projectTestSem3_Server.Models;

namespace projectTestSem3_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodProvidersController : ControllerBase
    {
        private readonly projectTestSem3_ServerContext _context;

        public BloodProvidersController(projectTestSem3_ServerContext context)
        {
            _context = context;
        }

        // GET: api/BloodProviders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BloodProvider>>> GetBloodProvider()
        {
            return await _context.BloodProvider.ToListAsync();
        }

        // GET: api/BloodProviders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BloodProvider>> GetBloodProvider(int id)
        {
            var bloodProvider = await _context.BloodProvider.FindAsync(id);

            if (bloodProvider == null)
            {
                return NotFound();
            }

            return bloodProvider;
        }

        // PUT: api/BloodProviders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBloodProvider(int id, BloodProvider bloodProvider)
        {
            if (id != bloodProvider.Id)
            {
                return BadRequest();
            }

            _context.Entry(bloodProvider).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BloodProviderExists(id))
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

        // POST: api/BloodProviders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BloodProvider>> PostBloodProvider(BloodProvider bloodProvider)
        {
            _context.BloodProvider.Add(bloodProvider);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBloodProvider", new { id = bloodProvider.Id }, bloodProvider);
        }

        // DELETE: api/BloodProviders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBloodProvider(int id)
        {
            var bloodProvider = await _context.BloodProvider.FindAsync(id);
            if (bloodProvider == null)
            {
                return NotFound();
            }

            _context.BloodProvider.Remove(bloodProvider);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BloodProviderExists(int id)
        {
            return _context.BloodProvider.Any(e => e.Id == id);
        }
    }
}
