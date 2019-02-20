using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Tour.Heroes.Api.Models.Entities.LinkEntities;
using Tour.Heroes.Api.Repositories.LinkEntityRepositories;

namespace Tour.Heroes.Api.Controllers
{
    /// <summary>
    /// Controller to create and delete relations between 
    /// <see cref="Models.Entities.MetaHuman"/> 
    /// and <see cref="Models.Entities.Ability"/>
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MetaHumansAbilitiesController : ControllerBase
    {
        private readonly MetaHumansAbilitiesRepository metahumanAbilitiesRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="MetaHumansAbilitiesController"/> class.
        /// </summary>
        /// <param name="context">The database context</param>
        public MetaHumansAbilitiesController(HeroDbContext context)
        {
            this.metahumanAbilitiesRepository = new MetaHumansAbilitiesRepository(context);
        }

        /// <summary>
        /// POST: api/HeroesAbilities
        /// </summary>
        /// <param name="ma"></param>
        /// <returns></returns>        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MetaHumanAbility ma)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var stored = await this.metahumanAbilitiesRepository.AddAsync(ma);

                return Ok(new { id = new { stored.MetaHumanId, stored.AbilityId } });
            }
            catch (DbUpdateException)
            {
                if (await this.metahumanAbilitiesRepository.EntityExists(ma))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// POST: api/metahumansAbilities/delete 
        /// </summary>
        /// <param name="ma"></param>
        /// <returns></returns>
        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] MetaHumanAbility ma)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var ha = await this.metahumanAbilitiesRepository.DeleteAsync(ma.MetaHumanId, ma.AbilityId);

                return Ok(new { id = new { ha.MetaHumanId, ha.AbilityId } });
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}