using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tour.Heroes.Api;
using Tour.Heroes.Api.Models;
using Tour.Heroes.Api.Models.RequestModels;
using Tour.Heroes.Api.Models.ViewModels;
using Tour.Heroes.Api.Repositories;

namespace Tour.Heroes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private readonly HeroDbContext _context;
        private HeroesRepository heroesRepository;

        public HeroesController(HeroDbContext context)
        {
            _context = context;
            this.heroesRepository = new HeroesRepository(context);
        }

        // GET: api/Heroes
        [HttpGet]
        public IActionResult GetHeroes([FromQuery]CollectionRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int skip = 0;

            var query = this.heroesRepository.GetAll();

            if (model.AbilityCount > 0)
            {
                query = query.Where(x => x.AbilitiesHeroes.Count > model.AbilityCount);
            }

            if (model.Skip != null && model.Skip > 0)
            {
                skip = (int)model.Skip;
            }

            if (!string.IsNullOrEmpty(model.Name))
            {
                query = query.Where(x => x.Name.Contains(model.Name));
            }

            query = query
                .Skip(skip)
                .Take(25);

            var viewQuery = SelectViewModel(query);

            return Ok(viewQuery.ToList());
        }

        private IQueryable<HeroViewModel> SelectViewModel(IQueryable<Hero> query)
        {
            return query.Select(x => new HeroViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Abilities = x.AbilitiesHeroes
                                .Select(c => c.Ability)
                                .Select(c => new AbilityViewModel()
                                {
                                    Id = c.Id,
                                    Name = c.Name,
                                    Description = c.Description
                                })
            });
        }

       // GET: api/Heroes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var q = this.heroesRepository.GetOne(id);

            var viewQuery = SelectViewModel(q);

            HeroViewModel hero = await viewQuery.FirstAsync();

            if (hero == null)
            {
                return NotFound();
            }

            return Ok(hero);
        }

        // PUT: api/Heroes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHero([FromRoute] Guid id, [FromBody] Hero hero)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hero.Id)
            {
                return BadRequest();
            }

            _context.Entry(hero).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HeroExists(id))
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

        // POST: api/Heroes
        [HttpPost]
        public async Task<IActionResult> PostHero([FromBody] Hero hero)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Heroes.Add(hero);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHero", new { id = hero.Id }, hero);
        }

        // DELETE: api/Heroes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHero([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hero = await _context.Heroes.FindAsync(id);
            if (hero == null)
            {
                return NotFound();
            }

            _context.Heroes.Remove(hero);
            await _context.SaveChangesAsync();

            return Ok(hero);
        }

        private bool HeroExists(Guid id)
        {
            return _context.Heroes.Any(e => e.Id == id);
        }
    }
}