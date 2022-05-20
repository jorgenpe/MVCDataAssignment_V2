using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCDataAssignment_V2.Models.ViewModels;
using MVCDataAssignment_V2.Models;

namespace MVCDataAssignment_V2.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityService _cityService;
        private readonly ICountryService _countryService;

        public CityController(ICityService cityService, ICountryService countryService)
        {
            _cityService = cityService;
            _countryService = countryService;
        }

        public IActionResult Index()
        {
            CreateCityViewModel createCity = new CreateCityViewModel();

            createCity.CountrysList = _countryService.All();
            return View(createCity);
        }

        


        public IActionResult City()
        {
            return View();
        }

        public IActionResult GetCity()
        {
            return PartialView("_CitysList", _cityService.All());
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateCityViewModel createCity = new CreateCityViewModel();

            createCity.CountrysList = _countryService.All();

            return View(createCity);
        }

        [HttpPost]
        public IActionResult Create(CreateCityViewModel createCity)
        {
            

            if (ModelState.IsValid && createCity != null)
            {
                _cityService.Add(createCity);

                return RedirectToAction("Index");
            }

            createCity.CountrysList = _countryService.All();

            
            return View(createCity);

        }



        [HttpPost]
        public IActionResult Delete(int deleteId)
        {
            if (ModelState.IsValid && _cityService.FindById(deleteId) != null)
            {
                List<City> listCity = new List<City>();
                listCity.Add(_cityService.FindById(deleteId));
                _cityService.Remove(deleteId);


                return PartialView("_CitysListThree", listCity);
            }
            return PartialView("_CityFailedDelete");
        }
    }
}
