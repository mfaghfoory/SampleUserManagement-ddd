using Microsoft.EntityFrameworkCore;
using SampleUserManagement.Datalayer;
using SampleUserManagement.Domain;
using SampleUserManagement.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleUserManagement.Repository.Implements
{
    public class BaseRepository<TKey, TEntity> : IBaseRepository<TKey, TEntity> where TEntity : BaseEntity<TKey>
    {
        protected readonly UserManagementDbContext dbContext;
        protected readonly DbSet<TEntity> entities;
        public BaseRepository(UserManagementDbContext dbContext)
        {
            this.dbContext = dbContext;
            entities = dbContext.Set<TEntity>();
        }

        public virtual async Task<TEntity> Find(TKey id)
        {
            return await entities.FindAsync(id);
        }

        public virtual async Task<ICollection<TEntity>> GetAll()
        {
            return await entities.ToListAsync();
        }

        public virtual TEntity Remove(TEntity entity)
        {
            return entities.Remove(entity).Entity;
        }

        public virtual TEntity Update(TEntity entity)
        {
            return entities.Update(entity).Entity;
        }

        public virtual async Task<TEntity> Add(TEntity entity)
        {
            return (await entities.AddAsync(entity)).Entity;
        }

        public virtual async Task<int> SaveChanges()
        {
            return await dbContext.SaveChangesAsync();
        }
    }
}
