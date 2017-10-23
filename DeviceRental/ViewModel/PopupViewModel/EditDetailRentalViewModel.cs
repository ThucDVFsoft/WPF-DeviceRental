using System;
using System.Collections.ObjectModel;
using DeviceRentalManagement.ModelEF;
using DeviceRentalManagement.Support;

namespace DeviceRentalManagement.ViewModel.PopupViewModel
{
   public class EditDetailRentalViewModel : BaseViewModel
    {
        private DeviceRental selectedRental;

        public EditDetailRentalViewModel(DeviceRental rental)
            :base()
        {
            selectedRental = rental;

            Devices = GetDevices();
            Employees = GetEmployees();
            SelectedEmployee = selectedRental.Employee;
            SelectedDevice = selectedRental.Device;
            Note = StringCopy(selectedRental.Note);
            RentalDate = NewDateTime(selectedRental.RentalDate);
            ExpiryDate = NewDateTime(selectedRental.ExpiryDate);
            SaveCommand = new RelayCommand<DeviceRental>(SaveCommandMethod);
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

        private string note;
        public string Note
        {
            get { return note; }
            set
            {
                note = value;
                OnPropertyChanged();
            }
        }

        private DateTime? rentalDate;
        public DateTime? RentalDate
        {
            get { return rentalDate; }
            set
            {
                rentalDate = value;
                OnPropertyChanged();
            }
        }

        private DateTime? expiryDate;
        public DateTime? ExpiryDate
        {
            get { return expiryDate; }
            set
            {
                expiryDate = value;
                OnPropertyChanged();
            }
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

        public RelayCommand<DeviceRental> SaveCommand { get; private set; }

        private void SaveCommandMethod(DeviceRental editedRental)
        {
            var rental = UpdatedRental();
            rentalRepository.Update(rental);
            OnClosingRequest();
        }

        public event EventHandler ClosingRequest;

        protected void OnClosingRequest()
        {
            if (this.ClosingRequest != null)
            {
                this.ClosingRequest(this, EventArgs.Empty);
            }
        }

        private DeviceRental UpdatedRental()
        {
            var temp = rentalRepository.DbSet.Find(selectedRental.SId);
            temp.Device = selectedDevice;
            temp.Employee = selectedEmployee;
            temp.RentalDate = RentalDate;
            temp.ExpiryDate = ExpiryDate;
            temp.Note = Note;
            return temp;
        }
    }
}
