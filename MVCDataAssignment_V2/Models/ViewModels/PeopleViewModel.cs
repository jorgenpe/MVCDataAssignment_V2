
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCDataAssignment_V2.Models;

namespace MVCDataAssignment_V2.Models
{
    public class PeopleViewModel
    {
        public List<Person> PeopleListView { get; set; }

        public string FilterString { get; set; }

        public PeopleViewModel()
        { 
            PeopleListView = new List<Person>(); 
        }
    }
}

