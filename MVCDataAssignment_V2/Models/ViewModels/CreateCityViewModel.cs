using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MVCDataAssignment_V2.Models;


namespace MVCDataAssignment_V2.Models.ViewModels
{
    public class CreateCityViewModel
    {
        [Required]
        [StringLength(255)]
        public string CityName { get; set; }

        [Required]
        public int CountryId { get; set; }
        public Country CountryName { get; set; }

        public List<Person> people { get; set; }
        public List<Country> CountrysList { get; set; }
    }
}
