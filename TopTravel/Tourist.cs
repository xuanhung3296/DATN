//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TopTravel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tourist
    {
        public int TouristID { get; set; }
        public Nullable<int> BookTourID { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public string Gender { get; set; }
        public string TouristType { get; set; }
        public string Nationality { get; set; }
        public Nullable<float> Passport { get; set; }
        public Nullable<System.DateTime> ExpiredDate { get; set; }
        public Nullable<int> Status { get; set; }
    
        public virtual BookTour BookTour { get; set; }
    }
}
