using CollectionsManagment.Abstractions.GenRepositoryAbstractions;
using CollectionsManagment.DataBase;
using CollectionsManagment.DataBase.Entities;
using Microsoft.EntityFrameworkCore; 
using System.Linq.Expressions; 

namespace CollectionsManagment.GenericRepository.GenRepository
{
    public class Repository<T> : IRepository<T> where T : class, IBaseEntity
    {
        private readonly CollectionsManagmentContext context;
        private readonly DbSet<T> DbSet;

        public Repository(CollectionsManagmentContext context)
        {
            this.context = context;
            DbSet = context.Set<T>();
        }

        public virtual async Task AddAsync(T entity)
        {
            await DbSet.AddAsync(entity);
        }

        public virtual async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await DbSet.AddRangeAsync(entities);
        }

        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> searchExpression,
            params Expression<Func<T, object>>[] includes)
        {

            var result = DbSet.Where(searchExpression);

            if (result.Any())
            {
                result = includes.Aggregate(result, (current, include) =>
                current.Include(include));
            }

            return result;

        }

        public virtual IQueryable<T> Get()
        {
            return DbSet.AsNoTracking();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<T?> GetByIdAsync(int id)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id));
        } 

        public virtual void Remove(T entity)
        {
            DbSet.Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<T> entity)
        {
            DbSet.RemoveRange(entity);
        }

        public virtual void Update(T entity)
        {
            DbSet.Update(entity);
        }

        public virtual void UpdateRange(IEnumerable<T> entity)
        {
            DbSet.UpdateRange(entity);
        }
    }
}
