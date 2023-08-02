using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using TravelAgencyProject.Models;

namespace TravelAgencyProject.Dal
{
    public partial class FlightsDAL : DbContext
    {
        public FlightsDAL()
            : base("name=Database")
        {
        }

        public virtual DbSet<Flights> Flights { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flights>()
                .Property(e => e.From)
                .IsUnicode(false);

            modelBuilder.Entity<Flights>()
                .Property(e => e.To)
                .IsUnicode(false);
        }
    }
}
