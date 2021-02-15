using SampleUserManagement.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleUserManagement.Repository.Interfaces
{
    public interface IBaseRepository<TKey, TEntity> where TEntity: BaseEntity<TKey>
    {
        Task<TEntity> Find(TKey id);
        TEntity Remove(TEntity entity);
        TEntity Update(TEntity entity);
        Task<TEntity> Add(TEntity entity);
        Task<ICollection<TEntity>> GetAll();

        Task<int> SaveChanges();
    }
}
