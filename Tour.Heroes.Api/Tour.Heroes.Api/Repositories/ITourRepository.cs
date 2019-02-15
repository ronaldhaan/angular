using System.Linq;
using Tour.Heroes.Api.Models.Entities;

namespace Tour.Heroes.Api.Repositories
{
    public interface ITourRepository
    {
        IQueryable<ITourEntityModel> GetRelations(IQueryable<ITourEntityModel> query);
    }
}