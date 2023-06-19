using CollectionsManagment.DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsManagment.Abstractions.GenRepositoryAbstractions
{
    public interface IRepository<T> where T : IBaseEntity
    { 
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        IQueryable<T> Get();

        IQueryable<T> FindBy(Expression<Func<T, bool>> searchExpression,
            params Expression<Func<T, object>>[] includes);
         
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
         
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entity); 
         
        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entity);

    }
}
