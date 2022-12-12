using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelAgencyProject.Models
{
    public class Users
    {
        [Required(ErrorMessage = "first name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "name must be 2-50 letters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "last name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "name must be 2-50 letters")]
        public string LastName { get; set; }

        [Key]
        [Required]
       [StringLength(100, MinimumLength = 5, ErrorMessage ="email must be in appropriate format")]
        public string Email { get; set; }

        [Required]
        [RegularExpression("^[0-9]{4}$", ErrorMessage = "must be 4 digits")]
        public string pass { get; set; }
    }

}