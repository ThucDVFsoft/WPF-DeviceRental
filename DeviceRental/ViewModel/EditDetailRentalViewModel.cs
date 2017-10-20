using DeviceRentalManagement.Model;
using System;
using DeviceRentalManagement.ModelEF.Repository;
using System.Threading.Tasks;
using System.Linq.Expressions;
using DeviceRentalManagement.ModelEF;
using System.Collections.ObjectModel;
using System.Linq;
using DeviceRentalManagement.ModelEF.Repository.Interface;
using DeviceRentalManagement.Support;
using System.Collections.Generic;

namespace DeviceRentalManagement.ViewModel.PopupViewModel
{
    class EditDetailRentalViewModel : BaseViewModel
    {
        private DeviceRentalModel selectedRental;
        private List<Device> devices;
        private List<Employee> employees;
        private readonly DeviceRepository deviceDbSet = new DeviceRepository(EntitiesManager.GetEntitiesInstance());
        private readonly EmployeeRepository employeeDbSet = new EmployeeRepository(EntitiesManager.GetEntitiesInstance());
        public EditDetailRentalViewModel(DeviceRentalModel rental)
            :base()
        {
            selectedRental = rental;
            SaveCommand = new RelayCommand<DeviceRental>(SaveCmdMethod);
            Initialize();
        }

        private void Initialize()
        {
            devices = deviceDbSet.GetList().ToList();
            employees = employeeDbSet.GetList().ToList();

            DeviceNames = GetDeviceNames();
            EmployeeNames = GetEmployeeNames();
            SelectedDeviceIndex = devices.FindIndex(s => s.DeviceId == selectedRental.DeviceRental.DeviceId);
            SelectedEmployeeIndex = employees.FindIndex(s => s.EmployeeId == selectedRental.DeviceRental.EmployeeId);

            SelectedNote = StringCopy(selectedRental.DeviceRental.Note);
            SelectedRentalDate = NewDateTime(selectedRental.DeviceRental.RentalDate);
            SelectedExpiryDate = NewDateTime(selectedRental.DeviceRental.ExpiryDate);
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
