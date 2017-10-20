using DeviceRentalManagement.Model;
using DeviceRentalManagement.ModelEF;
using DeviceRentalManagement.ModelEF.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceRentalManagement.ViewModel.PopupViewModel
{
    public class PopupBaseViewModel : BaseViewModel
    {
        protected readonly RentalRepository rentalRepository = new RentalRepository(EntitiesManager.GetEntitiesInstance());
        protected readonly DeviceRepository deviceRepository = new DeviceRepository(EntitiesManager.GetEntitiesInstance());
        protected readonly EmployeeRepository employeeRepository = new EmployeeRepository(EntitiesManager.GetEntitiesInstance());

        protected ObservableCollection<Device> GetDevices()
        {
            var deviceList = deviceRepository.GetList();
            var devices = new ObservableCollection<Device>(deviceList);
            return devices;
        }

        protected async Task<ObservableCollection<Device>> GetDevicesAsync()
        {
            var deviceList = await deviceRepository.GetListAsync();
            var devices = new ObservableCollection<Device>(deviceList);
            return devices;
        }

        protected ObservableCollection<Employee> GetEmployees()
        {
            var employeeList = employeeRepository.GetList();
            var employees = new ObservableCollection<Employee>(employeeList);
            return employees;
        }

        protected async Task<ObservableCollection<Employee>> GetEmployeesAsync()
        {
            var employeeList = await employeeRepository.GetListAsync();
            var employees = new ObservableCollection<Employee>(employeeList);
            return employees;
        }

        protected ObservableCollection<DeviceRental> GetRentals()
        {
            var rentalList = rentalRepository.GetList();
            var rentals = new ObservableCollection<DeviceRental>(rentalList);
            return rentals;
        }

        protected async Task<ObservableCollection<DeviceRental>> GetRentalsAsync()
        {
            var rentalList = await rentalRepository.GetListAsync();
            var rentals = new ObservableCollection<DeviceRental>(rentalList);
            return rentals;
        }

        protected string StringCopy(string source)
        {
            if (source == null) return null;

            return string.Copy(source);
        }

        protected DateTime? NewDateTime(DateTime? date)
        {
            if (date == null) return null;

            int year = date.Value.Year;
            int month = date.Value.Month;
            int day = date.Value.Day;
            return new DateTime(year, month, day);
        }

        public event EventHandler ClosingRequest;
        protected void OnClosingRequest()
        {
            if (this.ClosingRequest != null)
            {
                this.ClosingRequest(this, EventArgs.Empty);
            }
        }
    }
}
