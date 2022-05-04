using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCDataAssignment.Models
{
    public interface IPeopleRepo
    {
        Person Create(Person person);
        List<Person> Read();
        Person Read(int id);
        bool Update(Person person);
        bool Delete(Person person);
    }
}
