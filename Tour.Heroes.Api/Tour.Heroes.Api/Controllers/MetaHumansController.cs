using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    /// <summary>
    /// Api controller responsable for the Http actions to the entity <see cref="Models.Entities.MetaHuman"/>.
    /// </summary>    
    [Route("api/[controller]")]
    [ApiController]
    public class MetaHumansController : BaseController
    {
        private readonly MetaHumansRepository metasRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="MetaHumansController"/> class.
        /// </summary>
        /// <param name="context">The database context</param>
        /// <param name="mapper">auto mapper</param>
        public MetaHumansController(HeroDbContext context, IMapper mapper) : base(mapper)
        {
            this.metasRepository = new MetaHumansRepository(context);
        }

        #region Actions
        /// <summary>
        /// GET: api/metahumans
        /// </summary>
        /// <param name="model">The optional get parameters</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get([FromQuery] CollectionRequestModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                int skip = 0;

                var query = this.metasRepository.GetAll() as IQueryable<MetaHuman>;

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

                bool withRelations = !model.NoRelations;

                if(withRelations)
                {
                    query = this.metasRepository.GetRelations(query) as IQueryable<MetaHuman>;
                }

                var viewQuery = query.Select(x => ViewModelHelper.BuildMetaViewModel(x, withRelations));

                return Ok(viewQuery.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(new JsonResult(ex.Message));
            }
        }

        /// <summary>
        /// GET: api/metahumans/{id}
        /// </summary>
        /// <param name="id">The id of the entity</param>
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

                IQueryable<MetaHuman> query = this.metasRepository.GetAll()
                                                .Where(x => x.Id.Equals(id));

                bool withRelations = model.NoRelations;

                if (withRelations)
                {
                    query = this.metasRepository.GetRelations(query) as IQueryable<MetaHuman>;
                }

                var viewQuery = query.Select(metaHuman => ViewModelHelper.BuildMetaViewModel(metaHuman, withRelations));

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
        /// PUT: api/metahumans/{id}
        /// </summary>
        /// <param name="id">The id of the entity</param>
        /// <param name="metaMutate">The changes</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] MetaHumanMutateModel metaMutate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            MetaHuman metahuman = await this.metasRepository.GetOne(id);

            if (metahuman == null || id != metahuman.Id)
            {
                return BadRequest();
            }

            if(!string.IsNullOrEmpty(metaMutate.Name))
            {
                metahuman.Name = metaMutate.Name;
            }

            if (metaMutate.Description != null)
            {
                metahuman.Description = metaMutate.Description;
            }

            if (metaMutate.AlterEgo != null)
            {
                metahuman.AlterEgo = metaMutate.AlterEgo;
            }

            metahuman.UpdatedAt = metaMutate.UpdatedAt;

            try
            {
                await this.metasRepository.UpdateAsync(metahuman);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await this.metasRepository.EntityExists(id))
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
        public async Task<IActionResult> Post([FromBody] MetaHuman meta)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if(string.IsNullOrEmpty(meta.Name))
                {
                    return BadRequest();
                }

                MetaHuman stored = await this.metasRepository.AddAsync(meta);


                return Ok(new { id = stored.Id });
            }
            catch (Exception ex)
            {
                return BadRequest(new JsonResult(ex.Message));
            }
        }

        /// <summary>
        /// DELETE: api/metahumans/{guid}
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


                if (!(await this.metasRepository.DeleteAsync(id) is MetaHuman hero))
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