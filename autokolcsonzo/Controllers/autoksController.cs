using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using autokolcsonzo.Data;
using autokolcsonzo.Models;

namespace autokolcsonzo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class autoksController : ControllerBase
    {
        private readonly autokolcsonzoDbcontext _context;

        public autoksController(autokolcsonzoDbcontext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<autok>>> Getautok()
        {
            return await _context.autok.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<autok>> Getautok(int id)
        {
            var autok = await _context.autok.FindAsync(id);

            if (autok == null)
            {
                return NotFound();
            }

            return autok;
        }

        [HttpPost]
        public async Task<ActionResult<autok>> Postautok(autok autok)
        {
            _context.autok.Add(autok);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getautok", new { id = autok.Id }, autok);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Putautok(int id, autok autok)
        {
            if (id != autok.Id)
            {
                return BadRequest();
            }

            _context.Entry(autok).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!autokExists(id))
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

        



        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteautok(int id)
        {
            var autok = await _context.autok.FindAsync(id);
            if (autok == null)
            {
                return NotFound();
            }

            _context.autok.Remove(autok);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool autokExists(int id)
        {
            return _context.autok.Any(e => e.Id == id);
        }
    }
}
