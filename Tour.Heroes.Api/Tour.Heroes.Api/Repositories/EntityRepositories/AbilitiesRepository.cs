using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using Tour.Heroes.Api.Models.Entities;

namespace Tour.Heroes.Api.Repositories.EntityRepositories
{
    public class AbilitiesRepository : Repository<Ability>, ITourRepository
    {
        public AbilitiesRepository(HeroDbContext context) : base(context) { }

        public IQueryable<ITourEntityModel> GetRelations(IQueryable<ITourEntityModel> query)
        {
            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            var aquery = query as IQueryable<Ability>;

            return aquery
                .Include(x => x.MetaHumanAbilities)
                    .ThenInclude(x => x.MetaHuman);
        }
    }
}
