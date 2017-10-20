using DeviceRentalManagement.ModelEF.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DeviceRentalManagement.ModelEF.Repository
{
    class BaseRepository<T> : IRepository<T> where T : class
    {
        public readonly DbContext Context;
        public IDbSet<T> DbSet { get; set; }

        public BaseRepository(DbContext context)
        {
            Context = context;
            DbSet = context.Set<T>();
        }

        public virtual void Update(T entity)
        {
            DbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public virtual async Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> FilterFunc1 = null, Expression<Func<T, bool>> FilterFunc2 = null)
        {
            if (FilterFunc1 != null && FilterFunc2 != null)
            {
                return await DbSet.Where(FilterFunc1).Where(FilterFunc2).ToListAsync();
            }
            else if (FilterFunc1 == null && FilterFunc2 != null)
            {
                return await DbSet.Where(FilterFunc2).ToListAsync();
            }
            else if (FilterFunc1 != null && FilterFunc2 == null)
            {
                return await DbSet.Where(FilterFunc1).ToListAsync();
            }
            return await DbSet.ToListAsync();
        }

        public virtual List<T> GetList(Expression<Func<T, bool>> filter = null)
        {
            if (filter != null)
            {
                return DbSet.Where(filter).ToList();
            }
            return DbSet.ToList();
        }
    }
}
