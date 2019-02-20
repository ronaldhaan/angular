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
    public class TeamsController : BaseController
    {
        private readonly TeamsRepository teamsRepository;

        public TeamsController(HeroDbContext context, IMapper mapper) : base(mapper)
        {
            teamsRepository = new TeamsRepository(context);
        }

        /// <summary>
        /// GET: api/Teams
        /// </summary>
        /// <returns></returns>        
        [HttpGet]
        public IActionResult Get([FromQuery] CollectionRequestModel model)
        {
            try
            {
                var query = teamsRepository.GetAll();

                if(!string.IsNullOrEmpty(model.Name))
                {
                    query = query.Where(x => x.Name.Contains(model.Name));
                }

                bool withRelations = !model.NoRelations;

                if (withRelations)
                {
                    query = this.teamsRepository.GetRelations(query) as IQueryable<Team>;
                }

                //var response = mapper.Map<Collection<TeamViewModel>>(query);

                var viewModel = query.Select(x => ViewModelHelper.BuildTeamViewModel(x, withRelations));

                return Ok(viewModel.ToList());
            }
            catch(Exception ex)
            {
                return BadRequest(new JsonResult(ex.Message));
            }
        }

        /// <summary>
        /// GET: api/Teams/5
        /// </summary>
        /// <param name="id"></param>
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

                var query = teamsRepository.GetAll()
                                    .Where(x => x.Id.Equals(id));

                bool withRelations = !model.NoRelations;

                if (withRelations)
                {
                    query = this.teamsRepository.GetRelations(query) as IQueryable<Team>;
                }

                var viewQuery = query.Select(x => ViewModelHelper.BuildTeamViewModel(x, withRelations));

                TeamViewModel team = await viewQuery.FirstOrDefaultAsync();

                if (team == null)
                {
                    return NotFound();
                }

                return Ok(team);
            }
            catch (Exception ex)
            {
                return BadRequest(new JsonResult(ex.Message));
            }
}

        /// <summary>
        /// PUT: api/Teams/5
        /// </summary>
        /// <param name="id"></param>
        /// <param name="teamMutate"></param>
        /// <returns></returns>        
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] TeamMutateModel teamMutate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Team team = await this.teamsRepository.GetOne(id);

            if (team == null || id != team.Id)
            {
                return BadRequest();
            }

            if (!string.IsNullOrEmpty(teamMutate.Name))
            {
                team.Name = teamMutate.Name;
            }

            if (teamMutate.Description != null)
            {
                team.Description = teamMutate.Description;
            }
            
            team.UpdatedAt = teamMutate.UpdatedAt;

            try
            {
                await teamsRepository.UpdateAsync(team);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await teamsRepository.EntityExists(id))
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
        /// POST: api/Teams
        /// </summary>
        /// <param name="team"></param>
        /// <returns></returns>        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Team team)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if(string.IsNullOrEmpty(team.Name))
                {
                    return BadRequest();
                }

                Team stored = await teamsRepository.AddAsync(team);

                return Ok(new { id = stored.Id });
            }
            catch (Exception ex)
            {
                return BadRequest(new JsonResult(ex.Message));
            }
        }

        /// <summary>
        /// DELETE: api/Teams/5
        /// </summary>
        /// <param name="id"></param>
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

                Team team = await teamsRepository.DeleteAsync(id);

                return Ok(team);
            }
            catch (Exception ex)
            {
                return BadRequest(new JsonResult(ex.Message));
            }
        }
    }
}