using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataBaseFirstApproach.CTEModels;

namespace DataBaseFirstApproach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CteTablesController : ControllerBase
    {
        private readonly SqlPracticeContext _context;

        public CteTablesController(SqlPracticeContext context)
        {
            _context = context;
        }

        // GET: api/CteTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CteTable>>> GetCteTables()
        {
            return await _context.CteTables.ToListAsync();
        }

        // GET: api/CteTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CteTable>> GetCteTable(int id)
        {
            var cteTable = await _context.CteTables.FindAsync(id);

            if (cteTable == null)
            {
                return NotFound();
            }

            return cteTable;
        }

        // PUT: api/CteTables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCteTable(int id, CteTable cteTable)
        {
            if (id != cteTable.Id)
            {
                return BadRequest();
            }

            _context.Entry(cteTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CteTableExists(id))
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

        // POST: api/CteTables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CteTable>> PostCteTable(CteTable cteTable)
        {
            _context.CteTables.Add(cteTable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCteTable", new { id = cteTable.Id }, cteTable);
        }

        // DELETE: api/CteTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCteTable(int id)
        {
            var cteTable = await _context.CteTables.FindAsync(id);
            if (cteTable == null)
            {
                return NotFound();
            }

            _context.CteTables.Remove(cteTable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CteTableExists(int id)
        {
            return _context.CteTables.Any(e => e.Id == id);
        }
    }
}
