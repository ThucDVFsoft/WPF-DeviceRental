using System;
using System.Collections.ObjectModel;
using DeviceRentalManagement.ModelEF;
using DeviceRentalManagement.Support;
using System.Runtime.CompilerServices;

namespace DeviceRentalManagement.ViewModel.PopupViewModel
{
    public class AddDetailRentalViewModel : BaseViewModel
    {
        public DeviceRental newRental { get; private set; }
        public AddDetailRentalViewModel()
            :base()
        {
            Devices = GetDevices();
            Employees = GetEmployees();
            SaveCommand = new RelayCommand<string>(SaveCommandMethod, CanSaveMethod);
        }

        private ObservableCollection<Device> devices;
        public ObservableCollection<Device> Devices
        {
            get { return devices; }
            set
            {
                devices = value;
                this.OnPropertyChanged();
            }
        }

        private Device selectedDevice;
        public Device SelectedDevice
        {
            get { return selectedDevice; }
            set
            {
                selectedDevice = value;
                this.OnPropertyChanged();
            }
        }

        private ObservableCollection<Employee> employees;
        public ObservableCollection<Employee> Employees
        {
            get { return employees; }
            set
            {
                employees = value;
                this.OnPropertyChanged();
            }
        }

        private Employee selectedEmployee;
        public Employee SelectedEmployee
        {
            get { return selectedEmployee; }
            set
            {
                selectedEmployee = value;
                this.OnPropertyChanged();
            }
        }

        private DateTime? selectedRentalDate;
        public DateTime? SelectedRentalDate
        {
            get { return selectedRentalDate; }
            set
            {
                selectedRentalDate = value;
                this.OnPropertyChanged();
            }
        }

        private DateTime? selectedExpiryDate;
        public DateTime? SelectedExpiryDate
        {
            get { return selectedExpiryDate; }
            set
            {
                selectedExpiryDate = value;
                this.OnPropertyChanged();
            }
        }

        private string newNote;
        public string NewNote
        {
            get { return newNote; }
            set
            {
                newNote = value;
                this.OnPropertyChanged();
            }
        }

        public RelayCommand<string> SaveCommand { get; private set; }
        private void SaveCommandMethod(string param)
        {
            newRental = NewRental();
            rentalRepository.Add(newRental);
            OnClosingRequest();
        }
        private bool CanSaveMethod(string param = null)
        {
            if (SelectedDevice != null
                && SelectedEmployee != null
                && SelectedRentalDate != null
                && SelectedExpiryDate != null)
            {
                return true;
            }
            return false;
        }

        private new void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            base.OnPropertyChanged(propertyName);
            if (SaveCommand == null) return;
     
            SaveCommand.RaiseCanExecuteChanged();
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
