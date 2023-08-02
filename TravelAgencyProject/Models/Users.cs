namespace TravelAgencyProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Users
    {
        [Required(ErrorMessage = "first name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "name must be 2-50 letters")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "last name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "name must be 2-50 letters")]
        public string LastName { get; set; }

        [Key]
        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "email must be in appropriate format")]
        public string Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "password must be at least 4 letters" )]
        public string pass { get; set; }
    }
}
