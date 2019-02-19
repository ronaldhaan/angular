using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Tour.Heroes.Api.Models.Entities;
using Tour.Heroes.Api.Models.MutateModels;
using Tour.Heroes.Api.Models.RequestModels;
using Tour.Heroes.Api.Models.ViewModels;
using Tour.Heroes.Api.Repositories.EntityRepositories;

namespace Tour.Heroes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetaHumansController : BaseController
    {
        private readonly MetaHumansRepository heroesRepository;

        public MetaHumansController(HeroDbContext context, IMapper mapper) : base(mapper)
        {
            this.heroesRepository = new MetaHumansRepository(context);
        }

        #region Actions
        /// <summary>
        /// GET: api/Heroes
        /// </summary>
        /// <param name="model">The optional get parameters</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetHeroes([FromQuery]CollectionRequestModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                int skip = 0;

                var query = this.heroesRepository.GetAll() as IQueryable<MetaHuman>;

                if (model.Skip > 0)
                {
                    skip = (int)model.Skip;
                }

                if (!string.IsNullOrEmpty(model.Name))
                {
                    query = query.Where(x => x.Name.Contains(model.Name));
                }

                query = query
                    .OrderBy(x => x.Name)
                    .Skip(skip)
                    .Take(25);

                query = this.heroesRepository.GetRelations(query) as IQueryable<MetaHuman>;

                var viewQuery = query.Select(x => ViewModelHelper.BuildMetaViewModel(x, true));

                return Ok(viewQuery.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(new JsonResult(ex.Message));
            }
        }
                
        /// <summary>
        /// GET: api/Heroes/{id}
        /// </summary>
        /// <param name="id">The id of the entity</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                IQueryable<MetaHuman> query = this.heroesRepository.GetAll()
                                                .Where(x => x.Id.Equals(id));
                query = this.heroesRepository.GetRelations(query) as IQueryable<MetaHuman>;

                var viewQuery = query.Select(metaHuman => ViewModelHelper.BuildMetaViewModel(metaHuman, true));

                MetaHumanViewModel meta = await viewQuery.FirstOrDefaultAsync();

                if (meta == null)
                {
                    return NotFound();
                }

                return Ok(meta);
            }
            catch (Exception ex)
            {
                return BadRequest(new JsonResult(ex.Message));
            }
        }

        /// <summary>
        /// PUT: api/Heroes/{id}
        /// </summary>
        /// <param name="id">The id of the entity</param>
        /// <param name="metaMutate">The changes</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHero([FromRoute] Guid id, [FromBody] MetaHumanMutateModel metaMutate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            MetaHuman meta = new MetaHuman
            {
                Id = id,
                Name = metaMutate.Name,
                Description = metaMutate.Description,
                AlterEgo = metaMutate.AlterEgo,
                Status = metaMutate.Status
            };

            if (id != meta.Id)
            {
                return BadRequest();
            }

            try
            {
                await this.heroesRepository.UpdateAsync(meta);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await this.heroesRepository.EntityExists(id))
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
        /// POST: api/Heroes
        /// </summary>
        /// <param name="hero">The new entity</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostHero([FromBody] MetaHumanMutateModel metaMutate)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                MetaHuman meta = new MetaHuman
                {
                    Name = metaMutate.Name,
                    Description = metaMutate.Description,
                    AlterEgo = metaMutate.AlterEgo,
                    Status = metaMutate.Status
                };

                await this.heroesRepository.AddAsync(meta);


                return Ok(new { id = meta.Id });
            }
            catch (Exception ex)
            {
                return BadRequest(new JsonResult(ex.Message));
            }
        }

        /// <summary>
        /// DELETE: api/Heroes/5
        /// </summary>
        /// <param name="id">The id of the entity</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHero([FromRoute] Guid id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                if (!(await this.heroesRepository.DeleteAsync(id) is MetaHuman hero))
                {
                    return NotFound();
                }

                return Ok(hero);
            }
            catch (Exception ex)
            {
                return BadRequest(new JsonResult(ex.Message));
            }
        }

        #endregion Actions
    }
}