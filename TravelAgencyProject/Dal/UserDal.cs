using System;
using System.Collections.Generic;
using System.Data.Entity;
using TravelAgencyProject.Models;
using System.Linq;
using System.Web;

namespace TravelAgencyProject.Dal
{
    public class UserDal :DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Users>().ToTable("tblUsers");
        }
        public DbSet<Users>Users { get; set; }
    }
}