using System.Collections.Generic;
using DeviceRentalManagement.Support;
using System.Linq;

namespace DeviceRentalManagement.ViewModel
{
    class MainWindowViewModel : BaseViewModel
    {
        private BaseViewModel currentViewModel;
        private string selectedItem;
        private Dictionary<string, bool> menuSelectedState;
        private static readonly Dictionary<string, BaseViewModel> viewModelStorage
            = new Dictionary<string, BaseViewModel>()
            {
                { "Rental", new DeviceRentalViewModel() },
                { "Devices", new DeviceViewModel() },
                { "Employees", new EmployeeViewModel() },
            };

        public MainWindowViewModel()
        {
            CurrentViewModel = GetViewModel("Rental");
            MenuSelectedState = new Dictionary<string, bool>()
            {
                { "Rental", true },
                { "Devices", false },
                { "Employees", false },
            };
            selectedItem = "Rental";
            NavigateCommand = new RelayCommand<string>(Navigate);
        }

        public RelayCommand<string> NavigateCommand { get; private set; }

        public Dictionary<string, bool> MenuSelectedState 
        {
            get { return menuSelectedState; }
            set 
            {
                menuSelectedState = value;
                OnPropertyChanged();
            }
        }

        public BaseViewModel CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                currentViewModel = value;
                OnPropertyChanged();
            }
        }

        private void Navigate(string type)
        {
            UpdateMenuSelectedState(type);
            CurrentViewModel = GetViewModel(type);
        }

        private void UpdateMenuSelectedState(string type)
        {
            if (MenuSelectedState.ContainsKey(type) && MenuSelectedState.ContainsKey(selectedItem))
            {
                MenuSelectedState[selectedItem] = false;
                MenuSelectedState[type] = true;
                OnPropertyChanged("MenuSelectedState");
            }

            selectedItem = type;
        }

        private BaseViewModel GetViewModel(string type)
        {
            if (viewModelStorage.ContainsKey(type))
            {
                return viewModelStorage[type];
            }

            return CurrentViewModel;
        }
    }
}
