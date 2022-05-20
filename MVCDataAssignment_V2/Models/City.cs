using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCDataAssignment_V2.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MVCDataAssignment_V2.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        public string CityName { get; set; }

        
        [ForeignKey("Country")]
        public int? CountryId { get; set; }  
        public Country CountryName { get; set; }

        public List<Person> people { get; set; }
    }
}
