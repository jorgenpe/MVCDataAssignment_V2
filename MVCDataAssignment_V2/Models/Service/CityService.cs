using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCDataAssignment_V2.Models.ViewModels;
using MVCDataAssignment_V2.Models.Repo;

namespace MVCDataAssignment_V2.Models
{
    public class CityService : ICityService
    {
        private readonly ICitysRepo _citysRepo;
        private readonly ICountryService _countryService;

        Country country = new Country();

        public CityService(ICitysRepo citysRepo,ICountryService countryService )
        {
            this._citysRepo = citysRepo;
            _countryService = countryService;
        }

        public City Add(CreateCityViewModel CreateCity)
        {
            City newCity = new City() { Id = 0, CityName = CreateCity.CityName, 
                CountryName = _countryService.FindById(CreateCity.CountryId), CountryId = CreateCity.CountryId };
            //_countryService.FindById(city.CountryId)

            City createCity =_citysRepo.Create(newCity);

            return _citysRepo.Read(createCity.Id);
        }

        public List<City> All()
        {
            if (_citysRepo != null)
            {
                return _citysRepo.Read();

            }
            return null;
        }

        public List<City> Search(string search)
        {
            
           
            List<City> returnCity = new List<City>();
          
            foreach (City city in _citysRepo.Read())
            {
                
                if (city.CityName == search)
                {
                    returnCity.Add(city);
                              
                }


            }

            return returnCity;
        }

       

            public City FindById(int id)
        {
            return _citysRepo.Read(id);
        }

        public bool Edit(int id, CreateCityViewModel country)
        {
            City CityInList = new City();


            CityInList.Id = id;
            CityInList.CityName = country.CityName;


            return _citysRepo.Update(CityInList);
        }

        public bool Remove(int id)
        {
            return _citysRepo.Delete(FindById(id));
        }
    }
}
