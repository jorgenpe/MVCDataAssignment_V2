using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MVCDataAssignment_V2.Models;


namespace MVCDataAssignment_V2.Models.ViewModels
{
    public class CreateCountryViewModel
    {
        [Required]
        [StringLength(255)]
        public string CountryName { get; set; }
        public List<City> CountryCitys { get; set; }
    }
}
