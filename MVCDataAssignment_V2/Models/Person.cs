using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCDataAssignment_V2.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        [ForeignKey("City")]
        public int? CityId { get; set; }
        public City   CityName { get; set; }

        //[Required]
        //public int LanguageId { get; set; } 

        public List<PersonLanguage> PersonLanguages { get; set; }
    }
}