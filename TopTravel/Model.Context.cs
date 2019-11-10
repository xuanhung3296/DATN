﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using TopTravel.Common;

    public partial class BookingEntities : DbContext
    {
        public BookingEntities()
            : base("name=BookingEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Banner> Banners { get; set; }
        public virtual DbSet<BookTour> BookTours { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Tour> Tours { get; set; }
        public virtual DbSet<Tourist> Tourists { get; set; }
        public virtual DbSet<TourLabel> TourLabels { get; set; }
        public virtual DbSet<TourType> TourTypes { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public bool userIsValid(User user)
        {
            user.Password = Encrypt.Encode(user.Password);
            if (Users.Count(u => u.Email.Equals(user.Email) && u.Password.Equals(user.Password)) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
