using DeviceRentalManagement.Model;
using DeviceRentalManagement.ModelEF;
using DeviceRentalManagement.Support;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceRentalManagement.ViewModel.PopupViewModel
{
   public class EditDetailRentalViewModel : BaseViewModel
    {
        private DeviceRental selectedRental;
        private ObservableCollection<Device> devices;
        private ObservableCollection<Employee> employees;

        public EditDetailRentalViewModel(DeviceRental rental)
            :base()
        {
            selectedRental = rental;
            SaveCommand = new RelayCommand<DeviceRental>(SaveCmdMethod);
            Initialize();
        }

        private void Initialize()
        {
            DeviceNames = GetDeviceNames();
            EmployeeNames = GetEmployeeNames();

            SelectedDeviceIndex = new List<Device>(devices).FindIndex(s => s.DeviceId == selectedRental.DeviceId);
            SelectedEmployeeIndex = new List<Employee>(employees).FindIndex(s => s.EmployeeId == selectedRental.EmployeeId);
            SelectedNote = StringCopy(selectedRental.Note);
            SelectedRentalDate = NewDateTime(selectedRental.RentalDate);
            SelectedExpiryDate = NewDateTime(selectedRental.ExpiryDate);
        }

        private int selectedEmployeeIndex;
        public int SelectedEmployeeIndex
        {
            get { return selectedEmployeeIndex; }
            set
            {
                selectedEmployeeIndex = value;
                OnPropertyChanged();
            }
        }

        private int selectedDeviceIndex;
        public int SelectedDeviceIndex
        {
            get { return selectedDeviceIndex; }
            set
            {
                selectedDeviceIndex = value;
                SelectedDeviceCode = devices[selectedDeviceIndex].Code;
                SelectedDeviceType = devices[selectedDeviceIndex].Type;
                OnPropertyChanged();
            }
        }

        private string selectedDeviceCode;
        public string SelectedDeviceCode
        {
            get { return selectedDeviceCode; }
            set
            {
                selectedDeviceCode = value;
                OnPropertyChanged();
            }
        }

        private int selectedDeviceType;
        public int SelectedDeviceType
        {
            get { return selectedDeviceType; }
            set
            {
                selectedDeviceType = value;
                OnPropertyChanged();
            }
        }

        private string selectedNote;
        public string SelectedNote
        {
            get { return selectedNote; }
            set
            {
                selectedNote = value;
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

        private ObservableCollection<string> deviceNames;
        public ObservableCollection<string> DeviceNames
        {
            get { return deviceNames; }
            set
            {
                deviceNames = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<string> employeeNames;
        public ObservableCollection<string> EmployeeNames
        {
            get { return employeeNames; }
            set
            {
                employeeNames = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand<DeviceRental> SaveCommand { get; private set; }

        private void SaveCmdMethod(DeviceRental editedRental)
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
            temp.Device = devices[SelectedDeviceIndex];
            temp.Employee = employees[SelectedEmployeeIndex];
            temp.DeviceId = devices[SelectedDeviceIndex].DeviceId;
            temp.EmployeeId = employees[SelectedEmployeeIndex].EmployeeId;
            temp.RentalDate = SelectedRentalDate;
            temp.ExpiryDate = SelectedExpiryDate;
            temp.Note = SelectedNote;
            return temp;
        }

        private ObservableCollection<string> GetDeviceNames()
        {
            devices = GetDevices();
            var deviceNameList = devices.Select(s => s.Name).ToList();
            return new ObservableCollection<string>(deviceNameList);
        }

        private ObservableCollection<string> GetEmployeeNames()
        {
            employees = GetEmployees();
            var employeeNameList = employees.Select(s => s.Name).ToList();
            return new ObservableCollection<string>(employeeNameList);
        }
    }
}
