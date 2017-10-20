using DeviceRentalManagement.ModelEF;

namespace DeviceRentalManagement.Model
{
    class DeviceModel
    {
        public Device Device { get; set; }
        public DeviceModel(Device device)
        {
            this.Device = device;
        }
    }
}
