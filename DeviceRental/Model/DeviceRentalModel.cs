using DeviceRentalManagement.ModelEF;
using System;

namespace DeviceRentalManagement.Model
{
    public class DeviceRentalModel
    {
        public int SId { get; set; }
        public int EmployeeId { get; set; }
        public int DeviceId { get; set; }
        public Nullable<int> RentalStatus { get; set; }
        public Nullable<System.DateTime> RentalDate { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        public string Note { get; set; }

        public string DeviceName { get; set; }
        public string EmployeeName { get; set; }

        public DeviceRentalModel()
        {

        }

        public DeviceRentalModel(DeviceRental deviceRental)
        {
            this.SId = deviceRental.SId;
            this.EmployeeId = deviceRental.EmployeeId;
            this.DeviceId = deviceRental.DeviceId;
            this.RentalStatus = deviceRental.RentalStatus;
            this.RentalDate = deviceRental.RentalDate;
            this.ExpiryDate = deviceRental.ExpiryDate;
            this.Note = deviceRental.Note;
            this.DeviceName = deviceRental.Device.Name;
            this.EmployeeName = deviceRental.Employee.Name;
        }
    }
}
