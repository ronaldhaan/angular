using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Tour.Heroes.Api.Models.Entities.LinkEntities;

namespace Tour.Heroes.Api.Repositories.LinkEntityRepositories
{
    public class MetaHumansTeamsRepository : Repository<MetaHumanTeam>
    {
        public MetaHumansTeamsRepository(HeroDbContext context) : base(context) { }

        public IQueryable<ITourLinkModel> GetRelations(IQueryable<ITourLinkModel> query)
        {
            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            var hquery = query as IQueryable<MetaHumanTeam>;

            return hquery
                .Include(x => x.MetaHuman)
                .Include(x => x.Team);
        }
    }
}
