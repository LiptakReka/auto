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
    public class kolcsonzeseksController : ControllerBase
    {
        private readonly autokolcsonzoDbcontext _context;

        public kolcsonzeseksController(autokolcsonzoDbcontext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<kolcsonzesek>>> Getkolcsonzesek()
        {
            return await _context.kolcsonzesek.ToListAsync();
        }

        [HttpGet("ugyfel/{ugyfelid}")]
        public async Task<ActionResult<IEnumerable<kolcsonzesek>>> GetkolcsonzesekByUgyfel(int ugyfelid)
        {
            return await _context.kolcsonzesek
                .Where(k => k.ugyfelid == ugyfelid)
                .Include(k => k.autok)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<kolcsonzesek>> Getkolcsonzesek(int id)
        {
            var kolcsonzesek = await _context.kolcsonzesek.FindAsync(id);

            if (kolcsonzesek == null)
            {
                return NotFound();
            }

            return kolcsonzesek;
        }

        [HttpPost]
        public async Task<ActionResult<kolcsonzesek>> Postkolcsonzesek(kolcsonzesek kolcsonzesek)
        {
            _context.kolcsonzesek.Add(kolcsonzesek);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getkolcsonzesek", new { id = kolcsonzesek.Id }, kolcsonzesek);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Putkolcsonzesek(int id, kolcsonzesek kolcsonzesek)
        {
            if (id != kolcsonzesek.Id)
            {
                return BadRequest();
            }

            _context.Entry(kolcsonzesek).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!kolcsonzesekExists(id))
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
        public async Task<IActionResult> Deletekolcsonzesek(int id)
        {
            var kolcsonzesek = await _context.kolcsonzesek.FindAsync(id);
            if (kolcsonzesek == null)
            {
                return NotFound();
            }

            _context.kolcsonzesek.Remove(kolcsonzesek);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool kolcsonzesekExists(int id)
        {
            return _context.kolcsonzesek.Any(e => e.Id == id);
        }
    }
}
