using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using Tour.Heroes.Api.Models.Entities.LinkEntities;

namespace Tour.Heroes.Api.Repositories.LinkEntityRepositories
{
    public class MetaHumansAbilitiesRepository : Repository<MetaHumanAbility>
    {
        private readonly HeroDbContext context;

        public MetaHumansAbilitiesRepository(HeroDbContext context) : base(context)
        {
            this.context = context;
        }

        public IQueryable<ITourLinkModel> GetRelations(IQueryable<ITourLinkModel> query)
        {
            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            var hquery = query as IQueryable<MetaHumanAbility>;

            return hquery
                .Include(x => x.MetaHuman)
                .Include(x => x.Ability);
        }
    }
}
