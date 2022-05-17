using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCDataAssignment_V2.Data;

namespace MVCDataAssignment_V2.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
        public List<City> CountryCitys { get; set; }
    }
}
