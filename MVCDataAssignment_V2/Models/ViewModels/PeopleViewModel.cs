
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MVCDataAssignment.Models
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

