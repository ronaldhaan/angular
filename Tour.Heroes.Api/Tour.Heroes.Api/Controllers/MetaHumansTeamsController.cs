using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tour.Heroes.Api.Models.Entities.LinkEntities;
using Tour.Heroes.Api.Repositories.LinkEntityRepositories;

namespace Tour.Heroes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetaHumansTeamsController : ControllerBase
    {
        private readonly MetaHumansTeamsRepository metaHumansTeamsRepository;

        public MetaHumansTeamsController(HeroDbContext context)
        {
            metaHumansTeamsRepository = new MetaHumansTeamsRepository(context);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        // POST: api/MetaHumansTeams
        [HttpPost]
        public async Task<IActionResult> PostMetaHumanTeam([FromBody] MetaHumanTeam metaHumanTeam)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                try
                {
                    await metaHumansTeamsRepository.AddAsync(metaHumanTeam);
                }
                catch (DbUpdateException)
                {
                    if (await metaHumansTeamsRepository.EntityExists(metaHumanTeam.MetaHumanId, metaHumanTeam.TeamId))
                    {
                        return new StatusCodeResult(StatusCodes.Status409Conflict);
                    }
                    else
                    {
                        throw;
                    }
                }

                return Ok(metaHumanTeam);
            }
            catch(Exception ex)
            {
                return BadRequest(new JsonResult(ex.Message));
            }
        }

        // DELETE: api/MetaHumansTeams/delete
        [HttpPost("delete")]
        public async Task<IActionResult> DeleteMetaHumanTeam([FromBody] MetaHumanTeam metahumanTeam)
        {
            try {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var metaHumanTeam = await metaHumansTeamsRepository.DeleteAsync(metahumanTeam.MetaHumanId, metahumanTeam.TeamId);

                if (metaHumanTeam == null)
                {
                    return NotFound();
                }

                return Ok(metaHumanTeam);
            }
            catch(Exception ex)
            {
                return BadRequest(new JsonResult(ex.Message));
            }
        }

    }
}