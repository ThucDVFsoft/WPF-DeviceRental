using DeviceRentalManagement.ModelEF;

namespace DeviceRentalManagement.Model
{
    class EntitiesManager
    {
        private static Entities entitiesInstance;
        public static Entities GetEntitiesInstance()
        {
            if (entitiesInstance == null)
            {
                entitiesInstance = new Entities();
            }
            return entitiesInstance;
        }
    }
}
