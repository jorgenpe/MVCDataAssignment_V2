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

        [Required]
        public int CityId { get; set; }
        public City CityName { get; set; }
        public string NameCity { get; set; }

        [Required]
        public int CountryId { get; set; }
        public Country CountryName { get; set; }

        [Required]
        public int LanguageId { get; set; }

        
        public List<Language> Languages { get; set; }
        public List<City> Cities { get; set; }
        public List<Country> CountrysList { get; set; }
    }
}
