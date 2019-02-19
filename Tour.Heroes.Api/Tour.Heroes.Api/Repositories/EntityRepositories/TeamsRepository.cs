using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Tour.Heroes.Api.Models.Entities;

namespace Tour.Heroes.Api.Repositories.EntityRepositories
{
    public class TeamsRepository : Repository<Team>, ITourRepository
    {
        public TeamsRepository(HeroDbContext context) : base(context) { }

        public IQueryable<ITourEntityModel> GetRelations(IQueryable<ITourEntityModel> query)
        {
            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            var teamQuery = query as IQueryable<Team>;

            return teamQuery
                .Include(x => x.MetaHumanTeams)
                    .ThenInclude(x => x.MetaHuman);
        }
    }
}
