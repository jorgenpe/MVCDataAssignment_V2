using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCDataAssignment.Models
{
    public interface IPeopleService
    {
        Person Add(CreatePersonViewModel person);
        List<Person> All();
        List<Person> Search(string search);
        Person FindById(int id);
        bool Edit(int id, CreatePersonViewModel person);
        bool Remove(int id);
    }
}
