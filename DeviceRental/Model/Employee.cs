//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DeviceRental.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        public Employee()
        {
            this.DeviceRentals = new HashSet<DeviceRental>();
        }
    
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public byte[] Image { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> LastModified { get; set; }
        public Nullable<bool> Deleted { get; set; }
    
        public virtual ICollection<DeviceRental> DeviceRentals { get; set; }
    }
}
