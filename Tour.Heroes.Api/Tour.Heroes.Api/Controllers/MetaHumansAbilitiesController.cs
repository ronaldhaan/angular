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
    public class MetaHumansAbilitiesController : ControllerBase
    {
        private readonly MetaHumansAbilitiesRepository metahumanAbilitiesRepository;

        public MetaHumansAbilitiesController(HeroDbContext context)
        {
            this.metahumanAbilitiesRepository = new MetaHumansAbilitiesRepository(context);
        }

        // POST: api/HeroesAbilities
        [HttpPost]
        public async Task<IActionResult> PostmetahumansAbilities([FromBody] MetaHumanAbility metahumanAbilities)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await this.metahumanAbilitiesRepository.AddAsync(metahumanAbilities);
            }
            catch (DbUpdateException)
            {
                if (await this.metahumanAbilitiesRepository.EntityExists(metahumanAbilities))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return Ok(metahumanAbilities);
        }

        // POST: api/metahumansAbilities/delete
        [HttpPost("delete")]
        public async Task<IActionResult> DeletemetahumansAbilities([FromBody] MetaHumanAbility metahumansAbilities)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                MetaHumanAbility ha = await this.metahumanAbilitiesRepository.DeleteAsync(metahumansAbilities.MetaHumanId, metahumansAbilities.AbilityId);

                return Ok(ha);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}