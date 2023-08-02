namespace TravelAgencyProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Payment
    {
        [Key]
        public int ReservationId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [RegularExpression(@"^.{9,9}$", ErrorMessage = "9 digits required")]
        public int id { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number not valid")]
        public string PhoneNumber { get; set; }

        public int? TotalPrice { get; set; }

        [Required]
        [StringLength(16, MinimumLength = 10, ErrorMessage = "Credit card number not valid")]
        public string CardNumber { get; set; }
    }
}
