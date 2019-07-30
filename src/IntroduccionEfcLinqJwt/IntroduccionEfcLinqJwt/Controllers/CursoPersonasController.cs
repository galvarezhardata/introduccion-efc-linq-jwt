using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IntroduccionEfcLinqJwt.Models;

namespace IntroduccionEfcLinqJwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoPersonasController : ControllerBase
    {
        private readonly EfcLinqJwtIntroContext _context;

        public CursoPersonasController(EfcLinqJwtIntroContext context)
        {
            _context = context;
        }

        // GET: api/CursoPersonas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CursoPersona>>> GetCursoPersona()
        {
            return await _context.CursoPersona.ToListAsync();
        }

        // GET: api/CursoPersonas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CursoPersona>> GetCursoPersona(int id)
        {
            var cursoPersona = await _context.CursoPersona.FindAsync(id);

            if (cursoPersona == null)
            {
                return NotFound();
            }

            return cursoPersona;
        }

        // PUT: api/CursoPersonas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCursoPersona(int id, CursoPersona cursoPersona)
        {
            if (id != cursoPersona.Id)
            {
                return BadRequest();
            }

            _context.Entry(cursoPersona).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CursoPersonaExists(id))
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

        // POST: api/CursoPersonas
        [HttpPost]
        public async Task<ActionResult<CursoPersona>> PostCursoPersona(CursoPersona cursoPersona)
        {
            _context.CursoPersona.Add(cursoPersona);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCursoPersona", new { id = cursoPersona.Id }, cursoPersona);
        }

        // DELETE: api/CursoPersonas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CursoPersona>> DeleteCursoPersona(int id)
        {
            var cursoPersona = await _context.CursoPersona.FindAsync(id);
            if (cursoPersona == null)
            {
                return NotFound();
            }

            _context.CursoPersona.Remove(cursoPersona);
            await _context.SaveChangesAsync();

            return cursoPersona;
        }

        private bool CursoPersonaExists(int id)
        {
            return _context.CursoPersona.Any(e => e.Id == id);
        }
    }
}
