//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DeviceRentalManagement.ModelEF
{
    using System;
    using System.Collections.Generic;
    
    public partial class DeviceRental
    {
        public int SId { get; set; }
        public int EmployeeId { get; set; }
        public int DeviceId { get; set; }
        public Nullable<int> RentalStatus { get; set; }
        public Nullable<System.DateTime> RentalDate { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        public string Note { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> LastModified { get; set; }
    
        public virtual Device Device { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
