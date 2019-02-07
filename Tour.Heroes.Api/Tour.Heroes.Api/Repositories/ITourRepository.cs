using System;
using System.Linq;
using System.Threading.Tasks;
using Tour.Heroes.Api.Models;

namespace Tour.Heroes.Api.Repositories
{
    public interface ITourRepository
    {
        IQueryable<ITourModel> GetAll();

        IQueryable<ITourModel> GetOne(Guid id);

        Task UpdateAsync(Guid id, ITourModel model);

        Task<ITourModel> DeleteAsync(Guid id);

        Task AddAsync(ITourModel model);

        IQueryable<ITourModel> GetChildren(IQueryable<ITourModel> query);

        bool EntityExists(Guid id);
    }
}