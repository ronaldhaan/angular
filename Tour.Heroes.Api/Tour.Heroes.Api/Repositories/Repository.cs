using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Tour.Heroes.Api.Repositories
{
    /// <summary>
    /// Main repository class with the CRUD actions to the wanted entity T.
    /// </summary>
    /// <typeparam name="T">The type of the entity</typeparam>
    public class Repository<T> where T : class
    {        
        private DbContext Context { get; set; }
        private DbSet<T> DataSet { get; set; }

        /// <summary>
        /// Creates an instance of the <see cref="Tour.Heroes.Api.Repositories.Repository{T}"/>
        /// </summary>
        /// <param name="dbContext">The context this repository will use</param>
        public Repository(DbContext dbContext)
        {
            Context = dbContext;
            DataSet = dbContext.Set<T>();
        }

        /// <summary>
        /// Gets all the data from the database. 
        /// </summary>
        /// <returns>All data as <see cref="System.Linq.IQueryable{T}"/></returns>
        public virtual IQueryable<T> GetAll()
        {
            return DataSet;
        }

        /// <summary>
        /// Gets one entity from database based on the primary key.
        /// </summary>
        /// <param name="keyValues">The primary key</param>
        /// <returns>The entity</returns>
        public virtual Task<T> GetOne(params object[] keyValues)
        {
            return DataSet.FindAsync(keyValues);
        }

        /// <summary>
        /// Adds a new entity to the database.
        /// </summary>
        /// <param name="entity">The new entity</param>
        /// <returns>void</returns>
        /// <exception cref = "DbUpdateException" ></exception>
        /// <exception cref = "DbUpdateConcurrencyException" ></exception>
        public virtual async Task<int> AddAsync(T entity)
        {
            var result = DataSet.AddAsync(entity);
            return await this.SaveChangesAsync();
        }

        private Task<int> SaveChangesAsync()
        {
            return Context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates the given Entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref = "DbUpdateException" ></exception>
        /// <exception cref = "DbUpdateConcurrencyException" ></exception>
        public virtual async Task UpdateAsync(T entity)
        {
            this.Context.Entry(entity).State = EntityState.Modified;
            await this.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes the given entity.
        /// </summary>
        /// <param name="KeyValues">The primary key of the given entity</param>
        /// <returns>The given entity</returns>
        /// <exception cref = "DbUpdateException" ></exception>
        /// <exception cref = "DbUpdateConcurrencyException" ></exception>
        public virtual async Task<T> DeleteAsync(params object[] KeyValues)
        {
            T entity = await this.DataSet.FindAsync(KeyValues);

            if (entity == null)
            {
                return null;
            }

            this.DataSet.Remove(entity);
            await this.SaveChangesAsync();

            return entity;
        }

        /// <summary>
        /// Check weither the entity already exists in the database.
        /// </summary>
        /// <param name="KeyValues">The primary key of the given entity.</param>
        /// <returns></returns>
        public virtual async Task<bool> EntityExists(params object[] KeyValues)
        {
            return (await DataSet.FindAsync(KeyValues)) != null;
        }
    }
}
