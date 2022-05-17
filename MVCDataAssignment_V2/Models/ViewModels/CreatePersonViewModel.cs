using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MVCDataAssignment_V2.Models;

namespace MVCDataAssignment_V2.Models
{
    public class CreatePersonViewModel
    {
        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255)]
        public string LastName { get; set; }

        [Required]
        [StringLength(127)]
        public string PhoneNumber { get; set; }

        public City CityName { get; set; }
    }
}
