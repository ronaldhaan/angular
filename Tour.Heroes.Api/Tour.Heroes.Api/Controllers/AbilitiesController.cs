using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
    public class AbilitiesController : BaseController
    {
        private readonly AbilitiesRepository abilitiesRepository;

        public AbilitiesController(HeroDbContext context, IMapper mapper) : base(mapper)
        {
            this.abilitiesRepository = new AbilitiesRepository(context);
        }

        #region Actions
        // GET: api/Abilities
        [HttpGet]
        public ActionResult GetAbilities([FromQuery]CollectionRequestModel model)
        {
            try
            {
                int skip = 0;
                var query = this.abilitiesRepository.GetAll() as IQueryable<Ability>;
                query = this.abilitiesRepository.GetRelations(query) as IQueryable<Ability>;

                if (!string.IsNullOrEmpty(model.Name))
                {
                    query = query.Where(x => x.Name.Contains(model.Name));
                }

                if (model.Skip > 0)
                {
                    skip = (int)model.Skip;
                }

                query = query
                    .OrderBy(x => x.Name)
                    .Skip(skip)
                    .Take(25);

                IQueryable<AbilityViewModel> viewQuery = query.Select(x => ViewModelHelper.BuildAbilityViewModel(x, true));

                return Ok(viewQuery.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(new JsonResult(ex.Message));
            }
            //return Ok(this.mapper.Map<AbilityViewModel>(query));
        }

        // GET: api/Abilities/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var query = this.abilitiesRepository.GetAll()
                                .Where(x => x.Id.Equals(id)) 
                            as IQueryable<Ability>;

                query = this.abilitiesRepository.GetRelations(query) as IQueryable<Ability>;

                var viewModel = await query.Select(x => ViewModelHelper.BuildAbilityViewModel(x, true))
                                            .FirstOrDefaultAsync();
                //this.mapper.Map<AbilityViewModel>(query);

                if (viewModel == null)
                {
                    return NotFound();
                }

                return Ok(viewModel);
            }
            catch(Exception ex)
            {
                return BadRequest(new JsonResult(ex.Message));
            }
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
                return BadRequest(new JsonResult(ex.Message));
            }
        }

        // DELETE: api/Abilities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbility([FromRoute] Guid id)
        {
            try
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
            catch (Exception ex)
            {
                return BadRequest(new JsonResult(ex.Message));
            }
        }
        #endregion Actions
    }
}