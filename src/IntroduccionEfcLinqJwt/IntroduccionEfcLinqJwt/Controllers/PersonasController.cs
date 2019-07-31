using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IntroduccionEfcLinqJwt.Models;
using IntroduccionEfcLinqJwt.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace IntroduccionEfcLinqJwt.Controllers
{
    [Authorize(Policy = "Profesor")]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly EfcLinqJwtIntroContext _context;

        public PersonasController(EfcLinqJwtIntroContext context)
        {
            _context = context;
        }

        // GET: api/Personas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonasDto>>> GetPersonas()
        {
            // Forma síncronica.
            List<Rol> roles = await _context.Rol.ToListAsync();
            List <Persona> personas = await _context.Persona.ToListAsync();

            // Con LinQ.
            List<PersonasDto> personasDto = (from persona in personas
                      join rol in roles on persona.Rol
                      equals rol.Id
                      select new PersonasDto
                      {
                          Id = persona.Id,
                          Nombres = persona.Nombres,
                          Email = persona.Email,
                          Telefono = persona.Telefono,
                          Rol = rol.Descripcion
                      }).ToList();

            return personasDto;
        }

        // GET: api/Personas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Persona>> GetPersona(int id)
        {
            var persona = await _context.Persona.FindAsync(id);

            if (persona == null)
            {
                return NotFound();
            }

            return persona;
        }

        // PUT: api/Personas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersona(int id, Persona persona)
        {
            if (id != persona.Id)
            {
                return BadRequest();
            }

            _context.Entry(persona).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonaExists(id))
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

        // POST: api/Personas
        [HttpPost]
        public async Task<ActionResult<Persona>> PostPersona(Persona persona)
        {
            _context.Persona.Add(persona);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersona", new { id = persona.Id }, persona);
        }

        // DELETE: api/Personas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Persona>> DeletePersona(int id)
        {
            var persona = await _context.Persona.FindAsync(id);
            if (persona == null)
            {
                return NotFound();
            }

            _context.Persona.Remove(persona);
            await _context.SaveChangesAsync();

            return persona;
        }

        private bool PersonaExists(int id)
        {
            return _context.Persona.Any(e => e.Id == id);
        }
    }
}
