namespace TravelAgencyProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Flights
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string From { get; set; }

        [Required]
        [StringLength(50)]
        public string To { get; set; }

        public DateTime DepartDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public double Price { get; set; }

        public int Seats { get; set; }

        public TimeSpan DepartTime { get; set; }

        public TimeSpan ReturnTime { get; set; }


        [Required]
        [StringLength(50)]
        public string FlightType { get; set; }

        //[Column("One Way")]
        //public bool One_Way { get; set; }

        //[Column("Two Way")]
        //public bool Two_Way { get; set; }

    }
}
