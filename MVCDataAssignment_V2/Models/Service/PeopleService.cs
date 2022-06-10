using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCDataAssignment_V2.Models.ViewModels;
using MVCDataAssignment_V2.Models.Repo;

namespace MVCDataAssignment_V2.Models
{
    public class PeopleService : IPeopleService
    {

        private readonly IPeopleRepo _peopleRepo;
        private readonly ICityService _cityService;
        private readonly ICountryService _countryService;
        //private readonly IPersonLanguageRepo personLanguageRepo;

        

        public PeopleService(IPeopleRepo peopleRepo, ICityService cityService, ICountryService countryService)
        {
            this._peopleRepo = peopleRepo;
            _cityService = cityService;
            _countryService = countryService;   
        }

        public Person Add(CreatePersonViewModel person) 
        {
            if (string.IsNullOrWhiteSpace(person.FirstName))

            {
                throw new ArgumentException("Name,PhoneNumber or City, not be consist of backspace(s)/whitespace(s)");
            }
            else if(string.IsNullOrWhiteSpace(person.LastName))
            {
                {
                    throw new ArgumentException("Name,PhoneNumber or City, not be consist of backspace(s)/whitespace(s)");
                }
            }

            CreateCityViewModel city = new CreateCityViewModel() { CityName = _cityService.FindById(person.CityId).CityName
                , CountryId = person.CountryId, CountryName = _countryService.FindById(person.CountryId) , CountrysList = person.CountrysList
            };
            City newCity =_cityService.Add(city);

            

            Person newPerson = new Person() { PersonId = 0, FirstName = person.FirstName, LastName = person.LastName, PhoneNumber = person.PhoneNumber,
                            CityName = newCity, CityId = newCity.Id};

            Person createdPerson = _peopleRepo.Create(newPerson);

            //PersonLanguage personLanguage = new PersonLanguage() { PersonId = createdPerson.PersonId, LanguageId = person.LanguageId };
            return _peopleRepo.Read(createdPerson.PersonId);         }
        

        public List<Person> All() { 
            if(_peopleRepo != null)
            {
                return _peopleRepo.Read();

            }
            return null;    
        }

        public List<Person> Search(string search){

            List<Person> returnPeople = new List<Person>();
            foreach (Person person in _peopleRepo.Read())
            {
                if (person.FirstName == search)
                {
                    returnPeople.Add(person);
                }
                else if (person.LastName == search)
                {
                    returnPeople.Add(person);
                }
                else if (person.PhoneNumber == search)
                {
                    returnPeople.Add(person);
                }
                else if(person.CityName.CityName == search)
                {
                    returnPeople.Add(person);
                } 
                else if (person.CityName.CountryName.CountryName == search)
                {
                    returnPeople.Add(person);
                }

            }

            return returnPeople; }

        public Person FindById(int id) 
        { 
            return _peopleRepo.Read(id);
        }

        public bool Edit(int id, CreatePersonViewModel person) 
        {
            Person personInList = _peopleRepo.Read(id);

            
            
            personInList.FirstName = person.FirstName;
            personInList.LastName = person.LastName;
            personInList.PhoneNumber = person.PhoneNumber;
            personInList.CityId = person.CityId;
            personInList.CityName = _cityService.FindById(person.CityId);
            personInList.CityName.CountryId = person.CountryId;
            personInList.CityName.CountryName = _countryService.FindById(person.CountryId);


            return _peopleRepo.Update(personInList); 
        }

        public bool Remove(int id) 
        { 
            return _peopleRepo.Delete(FindById(id)); 
        }
    }
}
