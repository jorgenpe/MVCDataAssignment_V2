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
    }
}
/*<label asp-for="CityName"></label>


       < input asp -for= "CityName" list = "cityList" />
  

      < span asp - validation -for= "CountryId" ></ span >
      

          < select asp - items = "@(new SelectList(Model.Countrys,"Id",  "CountryName"))" asp -for= "CountryId" >
            

                </ select >
            
                < span asp - validation -for= "CountryId" ></ span >*/