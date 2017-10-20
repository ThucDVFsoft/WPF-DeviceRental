using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace DeviceRentalManagement.ModelEF.Repository
{
    class DeviceRepository : BaseRepository<Device>
    {
        public DeviceRepository(DbContext context)
            :base(context)
        {

        }
    }
}
