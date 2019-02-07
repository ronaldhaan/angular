using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tour.Heroes.Api.Models;

namespace Tour.Heroes.Api.Repositories
{
    public class HeroesRepository //: ITourRepository
    {
        private HeroDbContext context;

        public HeroesRepository(HeroDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Hero> GetAll()
        {
            var query = context.Heroes as IQueryable<Hero>;
                    
            query = this.GetAbilities(query)
                    .OrderBy(x => x.Name);            

            return query;
        }

        public IQueryable<Hero> GetOne(Guid id)
        {
            if(string.IsNullOrEmpty(id.ToString()))
            {
                throw new ArgumentNullException("id");
            }

            var query = context.Heroes
                .Where(x => x.Id == id)
            as IQueryable<Hero>;

            query = this.GetAbilities(query);

            return query;
        }

        private IQueryable<Hero> GetAbilities(IQueryable<Hero> query)
        {
            if(query == null)
            {
                throw new ArgumentNullException("query");
            }

            return query
                .Include(x => x.AbilitiesHeroes)
                .ThenInclude(x => x.Ability);
        }
    }
}
