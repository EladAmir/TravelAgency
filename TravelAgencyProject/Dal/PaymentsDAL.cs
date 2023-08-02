using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using TravelAgencyProject.Models;

namespace TravelAgencyProject.Dal
{
    public partial class PaymentsDAL : DbContext
    {
        public PaymentsDAL()
            : base("name=Database")
        {
        }

        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Flights> Flights { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payment>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Payment>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Payment>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Payment>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Payment>()
                .Property(e => e.CardNumber)
                .IsUnicode(false);
        }
    }
}
