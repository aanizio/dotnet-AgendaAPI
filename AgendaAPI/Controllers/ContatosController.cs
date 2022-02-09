#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgendaAPI.Models;

namespace AgendaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatosController : ControllerBase
    {
        private readonly ContatoContext _context;

        public ContatosController(ContatoContext context)
        {
            _context = context;
        }

        // GET: api/Contatos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContatoDTO>>> GetContatos()
        {
            return await _context.Contatos
                .Select(contato => ContatoToDTO(contato))
                .ToListAsync();
        }

        // GET: api/Contatos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContatoDTO>> GetContato(long id)
        {
            var contato = await _context.Contatos.FindAsync(id);

            if (contato == null)
            {
                return NotFound();
            }

            return ContatoToDTO(contato);
        }

        // PUT: api/Contatos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContato(long id, ContatoDTO contatoDTO)
        {
            if (id != contatoDTO.Id)
            {
                return BadRequest();
            }

            var contato = await _context.Contatos.FindAsync(id);
            ContatoFromDTO(contatoDTO, contato);

            _context.Entry(contato).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContatoExists(id))
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

        // POST: api/Contatos
        [HttpPost]
        public async Task<ActionResult<Contato>> PostContato(ContatoDTO contatoDTO)
        {
            var contato = ContatoFromDTO(contatoDTO);

            _context.Contatos.Add(contato);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetContato), new { id = contato.Id }, contato);
        }

        // DELETE: api/Contatos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContato(long id)
        {
            var contato = await _context.Contatos.FindAsync(id);
            if (contato == null)
            {
                return NotFound();
            }

            _context.Contatos.Remove(contato);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContatoExists(long id)
        {
            return _context.Contatos.Any(contato => contato.Id == id);
        }

        static private ContatoDTO ContatoToDTO(Contato contato) =>
            new ContatoDTO
            {
                Id = contato.Id,
                Nome = contato.Nome,
                Telefone = contato.Telefone,
                Email = contato.Email
            };

        static private Contato ContatoFromDTO(ContatoDTO dto)
        {
            var contato = new Contato();
            ContatoFromDTO(dto, contato);
            return contato;
        }
        
        static private void ContatoFromDTO(ContatoDTO dto, Contato contato)
        {
            contato.Id = dto.Id;
            contato.Nome = dto.Nome;
            contato.Telefone = dto.Telefone;
            contato.Email = dto.Email;
        }
    }
}
