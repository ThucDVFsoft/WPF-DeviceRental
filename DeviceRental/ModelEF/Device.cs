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
    
    public partial class Device
    {
        public Device()
        {
            this.DeviceRentals = new HashSet<DeviceRental>();
        }
    
        public int DeviceId { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public string Code { get; set; }
        public byte[] Image { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> LastModified { get; set; }
        public Nullable<bool> Deleted { get; set; }
    
        public virtual DeviceType DeviceType { get; set; }
        public virtual ICollection<DeviceRental> DeviceRentals { get; set; }
    }
}
