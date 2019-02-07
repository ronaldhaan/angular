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
        //private readonly HeroDbContext _context;
        private readonly HeroesRepository heroesRepository;

        public HeroesController(HeroDbContext context)
        {
            //_context = context;
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

            var query = this.heroesRepository.GetAll() as IQueryable<Hero>;

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
            return query.Select(hero => new HeroViewModel
            {
                Id = hero.Id,
                Name = hero.Name,
                Abilities = hero.AbilitiesHeroes
                                .Select(link => link.Ability)
                                .Select(ability => new AbilityViewModel()
                                {
                                    Id = ability.Id,
                                    Name = ability.Name,
                                    Description = ability.Description
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

            var q = this.heroesRepository.GetOne(id) as IQueryable<Hero>;

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

            try
            {
                await this.heroesRepository.UpdateAsync(id, hero);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.heroesRepository.EntityExists(id))
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

            await this.heroesRepository.AddAsync(hero);
            

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


            if (!(await this.heroesRepository.DeleteAsync(id) is Hero hero))
            {
                return NotFound();
            }

            return Ok(hero);
        }
    }
}