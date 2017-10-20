using DeviceRentalManagement.ModelEF;
using DeviceRentalManagement.Support;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceRentalManagement.ViewModel.PopupViewModel
{
    public class AddDetailRentalViewModel : BaseViewModel
    {

        public AddDetailRentalViewModel()
            :base()
        {
            Devices = new ObservableCollection<Device>(GetDevices());
            Employees = new ObservableCollection<Employee>(GetEmployees());
            SaveCommand = new RelayCommand<string>(SaveCommandMethod);
        }

        private ObservableCollection<Device> devices;
        public ObservableCollection<Device> Devices
        {
            get { return devices; }
            set
            {
                devices = value;
                OnPropertyChanged();
            }
        }

        private Device selectedDevice;
        public Device SelectedDevice
        {
            get { return selectedDevice; }
            set
            {
                selectedDevice = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Employee> employees;
        public ObservableCollection<Employee> Employees
        {
            get { return employees; }
            set
            {
                employees = value;
                OnPropertyChanged();
            }
        }

        private Employee selectedEmployee;
        public Employee SelectedEmployee
        {
            get { return selectedEmployee; }
            set
            {
                selectedEmployee = value;
                OnPropertyChanged();
            }
        }

        private DateTime? selectedRentalDate;
        public DateTime? SelectedRentalDate
        {
            get { return selectedRentalDate; }
            set
            {
                selectedRentalDate = value;
                OnPropertyChanged();
            }
        }

        private DateTime? selectedExpiryDate;
        public DateTime? SelectedExpiryDate
        {
            get { return selectedExpiryDate; }
            set
            {
                selectedExpiryDate = value;
                OnPropertyChanged();
            }
        }

        private string newNote;
        public string NewNote
        {
            get { return newNote; }
            set
            {
                newNote = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand<string> SaveCommand { get; private set; }
        private void SaveCommandMethod(string param)
        {
            var newRental = NewRental();
            rentalRepository.Add(newRental);
            OnClosingRequest();
        }

        private DeviceRental NewRental()
        {
            var newRental = new DeviceRental()
            {
                DateCreated = DateTime.Now,
                LastModified = DateTime.Now,
                RentalDate = SelectedRentalDate,
                ExpiryDate = SelectedExpiryDate,
                Device = SelectedDevice,
                DeviceId = SelectedDevice.DeviceId,
                Employee = SelectedEmployee,
                EmployeeId = SelectedEmployee.EmployeeId,
                Note = NewNote,
                RentalStatus = 1,
            };

            return newRental;
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
