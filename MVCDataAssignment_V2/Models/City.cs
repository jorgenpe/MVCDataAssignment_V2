using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCDataAssignment_V2.Data;

namespace MVCDataAssignment_V2.Models
{
    public class City
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public Country Country { get; set; }
        public List<Person> people { get; set; }
    }
}
