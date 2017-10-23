using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DeviceRentalManagement.Model;
using DeviceRentalManagement.ModelEF;
using DeviceRentalManagement.ModelEF.Repository;

namespace DeviceRentalManagement.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected readonly Entities entities = EntitiesManager.GetEntitiesInstance();

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged<T>(Expression<Func<T>> propertyLamda)
        {
            var me = propertyLamda as MemberExpression;

            if (me == null)
            {
                throw new ArgumentException(
                    "You must pass a lambda of the form: '() => Class.Property' or '() => object.Property'");
            }

            var handler = PropertyChanged;
            if (null == handler) return;
            handler(this, new PropertyChangedEventArgs(me.Member.Name));
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged == null) return;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        protected readonly RentalRepository rentalRepository = new RentalRepository(EntitiesManager.GetEntitiesInstance());
        protected readonly DeviceRepository deviceRepository = new DeviceRepository(EntitiesManager.GetEntitiesInstance());
        protected readonly EmployeeRepository employeeRepository = new EmployeeRepository(EntitiesManager.GetEntitiesInstance());

        protected ObservableCollection<Device> GetDevices()
        {
            var devices = deviceRepository.GetList();
            return new ObservableCollection<Device>(devices);
        }

        protected async Task<ObservableCollection<Device>> GetDevicesAsync()
        {
            var devices = await deviceRepository.GetListAsync();
            return new ObservableCollection<Device>(devices);
        }

        protected ObservableCollection<Employee> GetEmployees()
        {
            var employees = employeeRepository.GetList();
            return new ObservableCollection<Employee>(employees);
        }

        protected async Task<ObservableCollection<Employee>> GetEmployeesAsync()
        {
            var employees = await employeeRepository.GetListAsync();
            return new ObservableCollection<Employee>(employees);
        }

        protected ObservableCollection<DeviceRental> GetRentals()
        {
            var rentals = rentalRepository.GetList();
            return new ObservableCollection<DeviceRental>(rentals);
        }

        protected async Task<ObservableCollection<DeviceRental>> GetRentalsAsync()
        {
            var rentals = await rentalRepository.GetListAsync();
            return new ObservableCollection<DeviceRental>(rentals);
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
    }
}
