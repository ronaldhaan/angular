using System;
using System.Linq;
using Tour.Heroes.Api.Models;

namespace Tour.Heroes.Api.Repositories
{
    public interface ITourRepository
    {
        IQueryable<ITourModel> GetAll();

        IQueryable<ITourModel> GetOne(Guid id);
    }
}