using DeviceRentalManagement.Model;
using DeviceRentalManagement.ModelEF;
using DeviceRentalManagement.ModelEF.Repository;
using DeviceRentalManagement.Support;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DeviceRentalManagement.ViewModel.PopupViewModel
{
   public class EditDetailRentalViewModel : BaseViewModel
    {
        private DeviceRentalModel selectedRental;
        private List<Device> devices;
        private List<Employee> employees;
        private readonly RentalRepository rentalRepository = new RentalRepository(EntitiesManager.GetEntitiesInstance());
        private readonly DeviceRepository deviceRepository = new DeviceRepository(EntitiesManager.GetEntitiesInstance());
        private readonly EmployeeRepository employeeRepository = new EmployeeRepository(EntitiesManager.GetEntitiesInstance());
        public EditDetailRentalViewModel(DeviceRentalModel rental)
            :base()
        {
            selectedRental = rental;
            SaveCommand = new RelayCommand<DeviceRental>(SaveCmdMethod);
            Initialize();
        }

        private void Initialize()
        {
            devices = deviceRepository.GetList().ToList();
            employees = employeeRepository.GetList().ToList();

            DeviceNames = GetDeviceNames();
            EmployeeNames = GetEmployeeNames();
            SelectedDeviceIndex = devices.FindIndex(s => s.DeviceId == selectedRental.DeviceId);
            SelectedEmployeeIndex = employees.FindIndex(s => s.EmployeeId == selectedRental.EmployeeId);

            SelectedNote = StringCopy(selectedRental.Note);
            SelectedRentalDate = NewDateTime(selectedRental.RentalDate);
            SelectedExpiryDate = NewDateTime(selectedRental.ExpiryDate);
        }

        private string StringCopy(string source)
        {
            if (source == null) return null;

            return string.Copy(source);
        }

        private DateTime? NewDateTime(DateTime? date)
        {
            if (date == null) return null;

            int year = date.Value.Year;
            int month = date.Value.Month;
            int day = date.Value.Day;
            return new DateTime(year, month, day);
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
            var deviceNameList = devices.Select(s => s.Name).ToList();
            return new ObservableCollection<string>(deviceNameList);
        }

        private ObservableCollection<string> GetEmployeeNames()
        {
            var employeeNameList = employees.Select(s => s.Name).ToList();
            return new ObservableCollection<string>(employeeNameList);
        }
    }
}
