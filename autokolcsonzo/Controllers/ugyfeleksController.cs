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
    public class ugyfeleksController : ControllerBase
    {
        private readonly autokolcsonzoDbcontext _context;

        public ugyfeleksController(autokolcsonzoDbcontext context)
        {
            _context = context;
        }

 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ugyfelek>>> Getugyfelek()
        {
            return await _context.ugyfelek.ToListAsync();
        }

      
        [HttpGet("{id}")]
        public async Task<ActionResult<ugyfelek>> Getugyfelek(int id)
        {
            var ugyfelek = await _context.ugyfelek.FindAsync(id);

            if (ugyfelek == null)
            {
                return NotFound();
            }

            return ugyfelek;
        }

        [HttpPost]
        public async Task<ActionResult<ugyfelek>> Postugyfelek(ugyfelek ugyfelek)
        {
            _context.ugyfelek.Add(ugyfelek);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getugyfelek", new { id = ugyfelek.Id }, ugyfelek);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Putugyfelek(int id, ugyfelek ugyfelek)
        {
            if (id != ugyfelek.Id)
            {
                return BadRequest();
            }

            _context.Entry(ugyfelek).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ugyfelekExists(id))
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
        public async Task<IActionResult> Deleteugyfelek(int id)
        {
            var ugyfelek = await _context.ugyfelek.FindAsync(id);
            if (ugyfelek == null)
            {
                return NotFound();
            }

            _context.ugyfelek.Remove(ugyfelek);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ugyfelekExists(int id)
        {
            return _context.ugyfelek.Any(e => e.Id == id);
        }
    }
}
