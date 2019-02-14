using System;
using System.Linq;
using System.Threading.Tasks;
using Tour.Heroes.Api.Models;
using Tour.Heroes.Api.Models.Entities;

namespace Tour.Heroes.Api.Repositories
{
    public interface ITourRepository
    {
        IQueryable<ITourEntityModel> GetRelations(IQueryable<ITourEntityModel> query);
    }
}