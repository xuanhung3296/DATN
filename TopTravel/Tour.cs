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
    
    public partial class Tour
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tour()
        {
            this.BookTours = new HashSet<BookTour>();
            this.Comments = new HashSet<Comment>();
        }
    
        public int TourID { get; set; }
        public int TourTypeID { get; set; }
        public int TourLabelID { get; set; }
        public string TourName { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public string Duration { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> ListedPrice { get; set; }
        public Nullable<int> TotalSeat { get; set; }
        public Nullable<int> SeatAvailability { get; set; }
        public string Image { get; set; }
        public string TourProgram { get; set; }
        public string TourDetail { get; set; }
        public string Contact { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<bool> IsHot { get; set; }
        public Nullable<bool> OnHomePage { get; set; }
        public Nullable<int> Status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BookTour> BookTours { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual TourLabel TourLabel { get; set; }
        public virtual TourType TourType { get; set; }
    }
}
