using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tour.Heroes.Api;
using Tour.Heroes.Api.Models;
using Tour.Heroes.Api.Models.Entities;
using Tour.Heroes.Api.Models.RequestModels;
using Tour.Heroes.Api.Models.ViewModels;
using Tour.Heroes.Api.Repositories;
using Tour.Heroes.Api.Repositories.EntityRepositories;

namespace Tour.Heroes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbilitiesController : ControllerBase
    {
        private readonly AbilitiesRepository abilitiesRepository;

        public AbilitiesController(HeroDbContext context)
        {
            this.abilitiesRepository = new AbilitiesRepository(context);
        }

        #region Actions
        // GET: api/Abilities
        [HttpGet]
        public ActionResult GetAbilities([FromQuery]CollectionRequestModel model)
        {
            int skip = 0;
            var query = this.abilitiesRepository.GetAll() as IQueryable<Ability>;
            query = GetHeroes(query);

            if(!string.IsNullOrEmpty(model.Name))
            {
                query = query.Where(x => x.Name.Contains(model.Name));
            }

            if (model.Skip != null && model.Skip > 0)
            {
                skip = (int)model.Skip;
            }

            query = query
                .Skip(skip)
                .Take(25);

            var viewQuery = SelectViewModel(query);

            return Ok(viewQuery.ToList());
        }

        // GET: api/Abilities/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var q = this.abilitiesRepository.GetOne(id) as IQueryable<Ability>;
            q = this.GetHeroes(q);

            var viewQuery = SelectViewModel(q);

            AbilityViewModel ability = await viewQuery.FirstAsync();

            if (ability == null)
            {
                return NotFound();
            }

            return Ok(ability);
        }

        private IQueryable<Ability> GetHeroes(IQueryable<Ability> query)
        {
            return query.Include(x => x.MetaHumanAbilities)
                        .ThenInclude(x => x.MetaHuman);
        }

        // PUT: api/Abilities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAbility([FromRoute] Guid id, [FromBody] Ability ability)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ability.Id)
            {
                return BadRequest();
            }
            
            try
            {
                await this.abilitiesRepository.UpdateAsync(id, ability);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.abilitiesRepository.EntityExists(id))
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

        // POST: api/Abilities
        [HttpPost]
        public async Task<IActionResult> PostAbility([FromBody] Ability ability)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await this.abilitiesRepository.AddAsync(ability);

                return CreatedAtAction("GetAbility", new { id = ability.Id }, ability);
            }
            catch(DbUpdateException ex)
            {
                return new JsonResult(ex.Message);
            }
        }

        // DELETE: api/Abilities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbility([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!(await this.abilitiesRepository.DeleteAsync(id) is Ability ability))
            {
                return NotFound();
            }

            return Ok(ability);
        }
        #endregion Actions

        private IQueryable<AbilityViewModel> SelectViewModel(IQueryable<Ability> query)
        {
            return query.Select(ability => new AbilityViewModel
            {
                Id = ability.Id,
                Name = ability.Name,
                Description = ability.Description,
                Metahumans = ability.MetaHumanAbilities
                            .Select(link => link.MetaHuman)
                                .Select(hero => new MetaHumanViewModel()
                                {
                                    Id = hero.Id,
                                    Name = hero.Name
                                })
            });
        }
    }
}