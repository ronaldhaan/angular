using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tour.Heroes.Api;
using Tour.Heroes.Api.Models;
using Tour.Heroes.Api.Repositories;

namespace Tour.Abilities.Api.Repositories
{
    public class AbilitiesRepository : ITourRepository
    {
        private HeroDbContext context;

        public AbilitiesRepository(HeroDbContext context)
        {
            this.context = context;
        }

        public IQueryable<ITourModel> GetAll()
        {
            var query = context.Abilities as IQueryable<Ability>;

            query = (this.GetChildren(query) as IQueryable<Ability>)
                    .OrderBy(x => x.Name);

            return query;
        }

        public IQueryable<ITourModel> GetOne(Guid id)
        {
            if (string.IsNullOrEmpty(id.ToString()))
            {
                throw new ArgumentNullException("id");
            }

            var query = context.Abilities
                .Where(x => x.Id == id)
            as IQueryable<Ability>;

            query = this.GetChildren(query) as IQueryable<Ability>;

            return query;
        }

        public async Task AddAsync(ITourModel model)
        {
            Ability ability = model as Ability;

            this.context.Abilities.Add(ability);
            await this.context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates a Ability.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task UpdateAsync(Guid id, ITourModel model)
        {
            Ability ability = model as Ability;
            this.context.Entry(ability).State = EntityState.Modified;

            try
            {
                await this.context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;
            }
        }

        public async Task<ITourModel> DeleteAsync(Guid id)
        {
            Ability Ability = await this.context.Abilities.FindAsync(id);

            if (Ability == null)
            {
                return null; ;
            }

            this.context.Abilities.Remove(Ability);
            await this.context.SaveChangesAsync();

            return Ability;
        }

        public bool EntityExists(Guid id)
        {
            return this.context.Abilities.Any(e => e.Id == id);
        }

        public IQueryable<ITourModel> GetChildren(IQueryable<ITourModel> query)
        {
            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            var aquery = query as IQueryable<Ability>;

            return aquery
                .Include(x => x.HeroesAbilities)
                    .ThenInclude(x => x.Hero);
        }
    }
}
