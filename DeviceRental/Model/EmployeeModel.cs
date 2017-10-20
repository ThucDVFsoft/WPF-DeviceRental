using DeviceRentalManagement.ModelEF;

namespace DeviceRentalManagement.Model
{
    class EmployeeModel
    {
        public Employee Employee { get; set; }
        public EmployeeModel(Employee employee)
        {
            this.Employee = employee;
        }
    }
}
