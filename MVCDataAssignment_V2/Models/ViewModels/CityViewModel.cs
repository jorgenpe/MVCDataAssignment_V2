using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MVCDataAssignment_V2.Models;


namespace MVCDataAssignment_V2.Models.ViewModels
{
    public class CityViewModel
    {

        public List<City> cityListView { get; set; }

        public string FilterString { get; set; }

        public CityViewModel()
        {
            cityListView = new List<City>();
        }
    }
}
