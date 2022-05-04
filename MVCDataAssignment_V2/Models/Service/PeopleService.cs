using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCDataAssignment.Models
{
    public class PeopleService : IPeopleService
    {

        InMemoryPeopleRepo peopleRepo = new InMemoryPeopleRepo();    

        public PeopleService()
        {

        }

        public Person Add(CreatePersonViewModel person) 
        { 
            Person newPerson = new Person() { Id = 0, FirstName = person.FirstName, LastName = person.LastName, PhoneNumber = person.PhoneNumber, CityName = person.CityName};
            peopleRepo.Create(newPerson);
            return newPerson; 
        }
        
        public List<Person> All() { 
            if(peopleRepo != null)
            {
                return peopleRepo.Read();

            }
            return null;    
        }

        public List<Person> Search(string search){

            List<Person> returnPeople = new List<Person>();
            foreach (Person person in peopleRepo.Read())
            {
                if (person.FirstName == search)
                {
                     returnPeople.Add(person);
                }else if(person.LastName == search)
                { 
                    returnPeople.Add(person); 
                }else if(person.PhoneNumber == search)
                {
                    returnPeople.Add(person);
                }else if(person.CityName == search) 
                { 
                    returnPeople.Add(person); 
                }

            }

            return returnPeople; }

        public Person FindById(int id) 
        { 
            return peopleRepo.Read(id);
        }

        public bool Edit(int id, CreatePersonViewModel person) 
        {
            Person personInList = new Person();

            
            personInList.Id = id;
            personInList.FirstName = person.FirstName;
            personInList.LastName = person.LastName;
            personInList.PhoneNumber = person.PhoneNumber;
            personInList.CityName = person.CityName;

            return peopleRepo.Update(personInList); 
        }

        public bool Remove(int id) 
        { 
            return peopleRepo.Delete(FindById(id)); 
        }
    }
}
