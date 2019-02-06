using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tour.Heroes.Api;
using Tour.Heroes.Api.Models;

namespace Tour.Heroes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroAbilitiesController : ControllerBase
    {
        private readonly HeroDbContext _context;

        public HeroAbilitiesController(HeroDbContext context)
        {
            _context = context;
        }

        // GET: api/HeroAbilities
        [HttpGet]
        public IEnumerable<HeroAbilities> GetHeroAbilities()
        {
            return _context.HeroAbilities;
        }

        // GET: api/HeroAbilities/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHeroAbilities([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var heroAbilities = await _context.HeroAbilities.FindAsync(id);

            if (heroAbilities == null)
            {
                return NotFound();
            }

            return Ok(heroAbilities);
        }

        // PUT: api/HeroAbilities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHeroAbilities([FromRoute] Guid id, [FromBody] HeroAbilities heroAbilities)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != heroAbilities.HeroId)
            {
                return BadRequest();
            }

            _context.Entry(heroAbilities).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HeroAbilitiesExists(id))
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

        // POST: api/HeroAbilities
        [HttpPost]
        public async Task<IActionResult> PostHeroAbilities([FromBody] HeroAbilities heroAbilities)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.HeroAbilities.Add(heroAbilities);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HeroAbilitiesExists(heroAbilities.HeroId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHeroAbilities", new { id = heroAbilities.HeroId }, heroAbilities);
        }

        // DELETE: api/HeroAbilities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHeroAbilities([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var heroAbilities = await _context.HeroAbilities.FindAsync(id);
            if (heroAbilities == null)
            {
                return NotFound();
            }

            _context.HeroAbilities.Remove(heroAbilities);
            await _context.SaveChangesAsync();

            return Ok(heroAbilities);
        }

        private bool HeroAbilitiesExists(Guid id)
        {
            return _context.HeroAbilities.Any(e => e.HeroId == id);
        }
    }
}