using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tour.Heroes.Api.Models;

namespace Tour.Heroes.Api.Repositories
{
    public class HeroesRepository : ITourRepository
    {
        private HeroDbContext context;

        public HeroesRepository(HeroDbContext context)
        {
            this.context = context;
        }

        public IQueryable<ITourModel> GetAll()
        {
            var query = context.Heroes as IQueryable<Hero>;
                    
            query = (this.GetChildren(query) as IQueryable<Hero>)
                    .OrderBy(x => x.Name);            

            return query;
        }

        public IQueryable<ITourModel> GetOne(Guid id)
        {
            if(string.IsNullOrEmpty(id.ToString()))
            {
                throw new ArgumentNullException("id");
            }

            var query = context.Heroes
                .Where(x => x.Id == id)
            as IQueryable<Hero>;

            query = this.GetChildren(query) as IQueryable<Hero>;

            return query;
        }

        public IQueryable<ITourModel> GetChildren(IQueryable<ITourModel> query)
        {
            if(query == null)
            {
                throw new ArgumentNullException("query");
            }

            var hquery = query as IQueryable<Hero>;

            return hquery
                .Include(x => x.AbilitiesHeroes)
                    .ThenInclude(x => x.Ability);
        }

        public async Task AddAsync(ITourModel model)
        {
            Hero hero = model as Hero;
            this.context.Heroes.Add(hero);
            await this.context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates a hero.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hero"></param>
        /// <returns></returns>
        public async Task UpdateAsync(Guid id, ITourModel hero)
        {
            this.context.Entry(hero).State = EntityState.Modified;

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
            Hero hero = await this.context.Heroes.FindAsync(id);

            if (hero == null)
            {
                return null; ;
            }

            this.context.Heroes.Remove(hero);
            await this.context.SaveChangesAsync();

            return hero;
        }

        public bool EntityExists(Guid id)
        {
            return this.context.Heroes.Any(e => e.Id == id);
        }
    }
}
