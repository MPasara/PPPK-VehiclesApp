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
    
    public partial class TravelRoute
    {
        public int IDRoute { get; set; }
        public int TravelHours { get; set; }
        public double CoordinateA { get; set; }
        public double CoordinateB { get; set; }
        public int KilometersTavelled { get; set; }
        public double AverageSpeed { get; set; }
        public double FuelSpent { get; set; }
        public Nullable<int> TravelWarrantID { get; set; }
    
        public virtual TravelWarrant TravelWarrant { get; set; }
    }
}
