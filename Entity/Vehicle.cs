//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vehicle
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vehicle()
        {
            this.TravelWarrant = new HashSet<TravelWarrant>();
            this.VehicleService = new HashSet<VehicleService>();
        }
    
        public int IDVehicle { get; set; }
        public string VehicleType { get; set; }
        public string Make { get; set; }
        public int YearOfMake { get; set; }
        public int Kilometers { get; set; }
        public bool IsAvailable { get; set; }
        public string VehicleServiceDetails { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TravelWarrant> TravelWarrant { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VehicleService> VehicleService { get; set; }
    }
}
