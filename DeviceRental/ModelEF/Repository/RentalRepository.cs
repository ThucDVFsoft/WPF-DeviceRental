using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace DeviceRentalManagement.ModelEF.Repository
{
    public class RentalRepository : BaseRepository<DeviceRental>
    {
        public RentalRepository(DbContext context)
            :base(context)
        {

        }

        public override async Task<IEnumerable<DeviceRental>> GetListAsync(Expression<Func<DeviceRental, bool>> FilterFunc1 = null, Expression<Func<DeviceRental, bool>> FilterFunc2 = null)
        {
            if (FilterFunc1 != null && FilterFunc2 != null)
            {
                return await DbSet.Where(FilterFunc1).Where(FilterFunc2).Include("Device").Include("Employee").OrderBy(s => s.Employee.Name).ToListAsync();
            }
            else if (FilterFunc1 == null && FilterFunc2 != null)
            {
                return await DbSet.Where(FilterFunc2).Include("Device").Include("Employee").OrderBy(s => s.Employee.Name).ToListAsync();
            }
            else if (FilterFunc1 != null && FilterFunc2 == null)
            {
                return await DbSet.Where(FilterFunc1).Include("Device").Include("Employee").OrderBy(s => s.Employee.Name).ToListAsync();
            }
            return await DbSet.Include("Device").Include("Employee").OrderBy(s => s.Employee.Name).ToListAsync();
        }

        public override IEnumerable<DeviceRental> GetList(Expression<Func<DeviceRental, bool>> FilterFunc1 = null, Expression<Func<DeviceRental, bool>> FilterFunc2 = null)
        {
            if (FilterFunc1 != null && FilterFunc2 != null)
            {
                return DbSet.Where(FilterFunc1).Where(FilterFunc2).Include("Device").Include("Employee").OrderBy(s => s.Employee.Name);
            }
            else if (FilterFunc1 == null && FilterFunc2 != null)
            {
                return DbSet.Where(FilterFunc2).Include("Device").Include("Employee").OrderBy(s => s.Employee.Name);
            }
            else if (FilterFunc1 != null && FilterFunc2 == null)
            {
                return DbSet.Where(FilterFunc1).Include("Device").Include("Employee").OrderBy(s => s.Employee.Name);
            }
            return DbSet.Include("Device").Include("Employee").OrderBy(s => s.Employee.Name);
        }
    }
}
