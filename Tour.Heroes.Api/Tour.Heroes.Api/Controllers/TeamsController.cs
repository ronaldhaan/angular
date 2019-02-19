using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tour.Heroes.Api.Models.Entities;
using Tour.Heroes.Api.Models.MutateModels;
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

        // GET: api/Teams
        [HttpGet]
        public IActionResult GetTeam()
        {
            try
            {
                var query = teamsRepository.GetAll();

                query = teamsRepository.GetRelations(query) as IQueryable<Team>;

                //var response = mapper.Map<Collection<TeamViewModel>>(query);

                var viewModel = query.Select(x => ViewModelHelper.BuildTeamViewModel(x, true));

                return Ok(viewModel.ToList());
            }
            catch(Exception ex)
            {
                return BadRequest(new JsonResult(ex.Message));
            }
        }
        
        // GET: api/Teams/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeam([FromRoute] Guid id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var query = teamsRepository.GetAll()
                                    .Where(x => x.Id.Equals(id));

                query = this.teamsRepository.GetRelations(query) as IQueryable<Team>;

                var viewQuery = query.Select(x => ViewModelHelper.BuildTeamViewModel(x, true));

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

        // PUT: api/Teams/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeam([FromRoute] Guid id, [FromBody] TeamMutateModel teamMutate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Team team = new Team
            {
                Id = id,
                Name = teamMutate.Name,
                Description = teamMutate.Description,
            };

            if (id != team.Id)
            {
                return BadRequest();
            }

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

        // POST: api/Teams
        [HttpPost]
        public async Task<IActionResult> PostTeam([FromBody] TeamMutateModel teamMutate)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                Team team = new Team
                {
                    Name = teamMutate.Name,
                    Description = teamMutate.Description,
                };

                await teamsRepository.AddAsync(team);

                return Ok(team);
            }
            catch (Exception ex)
            {
                return BadRequest(new JsonResult(ex.Message));
            }
        }

        // DELETE: api/Teams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam([FromRoute] Guid id)
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