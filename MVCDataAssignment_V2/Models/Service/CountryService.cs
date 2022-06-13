using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCDataAssignment_V2.Models.ViewModels;
using MVCDataAssignment_V2.Models.Repo;

namespace MVCDataAssignment_V2.Models.Service
{
    public class CountryService : ICountryService
    {

        private readonly ICountryRepo _countryRepo;

        public CountryService(ICountryRepo countryRepo)
        {
            _countryRepo = countryRepo;
        }

        public Country Add(CreateCountryViewModel country) 
        {
            Country newCountry = new Country() { Id = 0, CountryName = country.CountryName };

            _countryRepo.Create(newCountry);

            return newCountry;
        }

        public List<Country> All()
        {
            if (_countryRepo != null)
            {
                return _countryRepo.Read();

            }
            return null;
        }

        public List<Country> Search(string search)
        {

            List<Country> returnCountry = new List<Country>();
            foreach (Country country in _countryRepo.Read())
            {
                if (country.CountryName == search)
                {
                    returnCountry.Add(country);
                }
               
            }

            return returnCountry;
        }

        public Country FindById(int id)
        {
            return _countryRepo.Read(id);
        }

        public bool Edit(int id, CreateCountryViewModel country)
        {
            Country CountryInList = new Country();


            CountryInList.Id = id;
            CountryInList.CountryName = country.CountryName;
            

            return _countryRepo.Update(CountryInList);
        }

        public bool Remove(int id)
        {
            return _countryRepo.Delete(FindById(id));
        }   
    }
}
