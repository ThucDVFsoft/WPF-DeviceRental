using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace DeviceRentalManagement.ModelEF.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>
    {
        public EmployeeRepository(DbContext context)
            :base(context)
        {

        }
    }
}
