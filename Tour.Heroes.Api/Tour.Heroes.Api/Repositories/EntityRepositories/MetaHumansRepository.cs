using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using Tour.Heroes.Api.Models.Entities;

namespace Tour.Heroes.Api.Repositories.EntityRepositories
{
    public class MetaHumansRepository : Repository<MetaHuman>, ITourRepository
    {
        public MetaHumansRepository(HeroDbContext context) : base(context) { }

        public IQueryable<ITourEntityModel> GetRelations(IQueryable<ITourEntityModel> query)
        {
            if(query == null)
            {
                throw new ArgumentNullException("query");
            }

            var metaQuery = query as IQueryable<MetaHuman>;

            return metaQuery
                        .Include(x => x.MetaHumanAbilities)
                            .ThenInclude(x => x.Ability)
                        .Include(x => x.MetaHumanTeams)
                            .ThenInclude(x => x.Team);
        }
    }
}
