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
    public class MoibiLinksController : ControllerBase
    {
        private readonly projectTestSem3_ServerContext _context;

        public MoibiLinksController(projectTestSem3_ServerContext context)
        {
            _context = context;
        }

        // GET: api/MoibiLinks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MoibiLink>>> GetMoibiLink()
        {
            return await _context.MoibiLink.ToListAsync();
        }

        // GET: api/MoibiLinks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MoibiLink>> GetMoibiLink(int id)
        {
            var moibiLink = await _context.MoibiLink.FindAsync(id);

            if (moibiLink == null)
            {
                return NotFound();
            }

            return moibiLink;
        }

        // PUT: api/MoibiLinks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMoibiLink(int id, MoibiLink moibiLink)
        {
            if (id != moibiLink.Id)
            {
                return BadRequest();
            }

            _context.Entry(moibiLink).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MoibiLinkExists(id))
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

        // POST: api/MoibiLinks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MoibiLink>> PostMoibiLink(MoibiLink moibiLink)
        {
            _context.MoibiLink.Add(moibiLink);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMoibiLink", new { id = moibiLink.Id }, moibiLink);
        }

        // DELETE: api/MoibiLinks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMoibiLink(int id)
        {
            var moibiLink = await _context.MoibiLink.FindAsync(id);
            if (moibiLink == null)
            {
                return NotFound();
            }

            _context.MoibiLink.Remove(moibiLink);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MoibiLinkExists(int id)
        {
            return _context.MoibiLink.Any(e => e.Id == id);
        }
    }
}
