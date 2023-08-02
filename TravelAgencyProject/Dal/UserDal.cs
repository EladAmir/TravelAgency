using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using TravelAgencyProject.Models;

namespace TravelAgencyProject.Dal
{
    public partial class UserDAL : DbContext
    {
        public UserDAL()
            : base("name=Database")
        {
        }

        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.pass)
                .IsUnicode(false);
        }
    }
}
