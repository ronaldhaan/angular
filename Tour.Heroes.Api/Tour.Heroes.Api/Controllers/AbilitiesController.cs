using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tour.Heroes.Api.Helpers;
using Tour.Heroes.Api.Models.Entities;
using Tour.Heroes.Api.Models.MutateModels;
using Tour.Heroes.Api.Models.RequestModels;
using Tour.Heroes.Api.Models.ViewModels;
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
        /// <summary>
        /// GET: api/Abilities
        /// </summary>
        /// <param name="model">The collection of the available get queries.</param>
        /// <returns></returns>        
        [HttpGet]
        public ActionResult Get([FromQuery]CollectionRequestModel model)
        {
            try
            {
                int skip = 0;
                var query = this.abilitiesRepository.GetAll() as IQueryable<Ability>;

                

                if (!string.IsNullOrEmpty(model.Name))
                {
                    query = query.Where(x => x.Name.Contains(model.Name));
                }

                if (model.Skip > 0)
                {
                    skip = model.Skip;
                }

                query = query
                    .OrderBy(x => x.Name)
                    .Skip(skip)
                    .Take(25);

                bool withRelations = !model.NoRelations;

                if (withRelations)
                {
                    query = this.abilitiesRepository.GetRelations(query) as IQueryable<Ability>;
                }

                IQueryable<AbilityViewModel> viewQuery = query.Select(x => ViewModelHelper.BuildAbilityViewModel(x, withRelations));

                return Ok(viewQuery.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(new JsonResult(ex.Message));
            }
            //return Ok(this.mapper.Map<AbilityViewModel>(query));
        }

        /// <summary>
        /// GET: api/Abilities/5
        /// </summary>
        /// <param name="id">The id of the wanted entity</param>
        /// <returns></returns>        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id, [FromQuery] CollectionRequestModel model)
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

                bool withRelations = !model.NoRelations;

                if (withRelations)
                {
                    query = this.abilitiesRepository.GetRelations(query) as IQueryable<Ability>;
                }

                var viewModel = await query.Select(x => ViewModelHelper.BuildAbilityViewModel(x, withRelations))
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

        /// <summary>
        /// PUT: api/Abilities/5
        /// </summary>
        /// <param name="id">The id of the entity</param>
        /// <param name="abilityMutate">The values allowed to be changed.</param>
        /// <returns></returns>        
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] AbilityMutateModel abilityMutate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Ability ability = await this.abilitiesRepository.GetOne(id);

            if (ability == null || id != ability.Id)
            {
                return BadRequest();
            }

            if(!string.IsNullOrEmpty(abilityMutate.Name))
            {
                ability.Name = abilityMutate.Name;

            }
            
            if (abilityMutate.Description != null)
            {
                ability.Description = abilityMutate.Description;
            }

            ability.UpdatedAt = abilityMutate.UpdatedAt;
            
            try
            {
                await this.abilitiesRepository.UpdateAsync(ability);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await this.abilitiesRepository.EntityExists(id))
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

        /// <summary>
        /// POST: api/Abilities
        /// </summary>
        /// <param name="abilityMutate">The values allowed to be changed.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Ability ability)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Ability stored = await this.abilitiesRepository.AddAsync(ability);

                return Ok(new { id = stored.Id });
            }
            catch(DbUpdateException ex)
            {
                return BadRequest(new JsonResult(ex.Message));
            }
        }

        /// <summary>
        /// DELETE: api/Abilities/5
        /// </summary>
        /// <param name="id">The id of the entity</param>
        /// <returns></returns>        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
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