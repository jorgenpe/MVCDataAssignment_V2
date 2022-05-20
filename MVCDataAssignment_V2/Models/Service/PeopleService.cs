﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCDataAssignment_V2.Models.ViewModels;

namespace MVCDataAssignment_V2.Models
{
    public class PeopleService : IPeopleService
    {

        private readonly IPeopleRepo _peopleRepo;
        private readonly ICityService _cityService;
        private readonly ICountryService _countryService;

        

        public PeopleService(IPeopleRepo peopleRepo, ICityService cityService, ICountryService countryService)
        {
            this._peopleRepo = peopleRepo;
            _cityService = cityService;
            _countryService = countryService;   
        }

        public Person Add(CreatePersonViewModel person) 
        { 
            
            CreateCityViewModel city = new CreateCityViewModel() { CityName = person.NameCity
                , CountryId = person.CountryId, CountryName = _countryService.FindById(person.CountryId) , CountrysList = person.CountrysList
            };
            City newCity =_cityService.Add(city);

            Person newPerson = new Person() { Id = 0, FirstName = person.FirstName, LastName = person.LastName, PhoneNumber = person.PhoneNumber,
                            CityName = newCity, CityId = newCity.Id};

            _peopleRepo.Create(newPerson);
            return newPerson;         }
        

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
                }else if(person.LastName == search)
                { 
                    returnPeople.Add(person); 
                }else if(person.PhoneNumber == search)
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
            Person personInList = new Person();

            
            personInList.Id = id;
            personInList.FirstName = person.FirstName;
            personInList.LastName = person.LastName;
            personInList.PhoneNumber = person.PhoneNumber;
            

            return _peopleRepo.Update(personInList); 
        }

        public bool Remove(int id) 
        { 
            return _peopleRepo.Delete(FindById(id)); 
        }
    }
}
