using System.Collections.Generic;
using DeviceRentalManagement.Support;

namespace DeviceRentalManagement.ViewModel
{
    class MainWindowViewModel : BaseViewModel
    {
        private BaseViewModel currentViewModel;
        private string selectedItem;
        private Dictionary<string, bool> menuSelectedState;

        private static readonly string[] ViewNames = new string[] { "Rental", "Devices", "Employees" };
        private static readonly Dictionary<string, BaseViewModel> viewModelStorage
            = new Dictionary<string, BaseViewModel>()
            {
                { ViewNames[0], new DeviceRentalViewModel() },
                { ViewNames[1], new DeviceViewModel() },
                { ViewNames[2], new EmployeeViewModel() },
            };

        public MainWindowViewModel()
        {
            CurrentViewModel = GetViewModel(ViewNames[0]);
            MenuSelectedState = new Dictionary<string, bool>()
            {
                { ViewNames[0], true },
                { ViewNames[1], false },
                { ViewNames[2], false },
            };
            selectedItem = ViewNames[0];
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
