using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCDataAssignment.Models
{
    public class InMemoryPeopleRepo : IPeopleRepo
    {

        static int idCounter = 0;
        static List<Person> people = new List<Person>();

        public InMemoryPeopleRepo()
        {

        }

        public Person Create(Person person) 
        {
            person.Id = ++idCounter;
            people.Add(person);

            return person; 
        }

        public List<Person> Read() 
        { 
            return  people; 
        }

        public Person Read(int id) 
        {
            foreach (Person person in people)
            {
                if (person.Id == id)
                {
                    return person;
                }
            }
            return null;
        }
    

        public bool Update(Person person)
        {
            foreach (Person personList in people)
            {
                if (personList.Id == person.Id)
                {
                    personList.FirstName = person.FirstName;
                    personList.LastName = person.LastName;
                    personList.PhoneNumber = person.PhoneNumber;
                    personList.CityName = person.CityName;
                    return true;
                }
            }
            return false; 
        }

        public bool Delete(Person person)
        {            
            return people.Remove(person); 
        }

    }
}
