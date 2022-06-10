using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCDataAssignment_V2.Models;
namespace MVCDataAssignment_V2.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IPeopleService _peopleService;
        private readonly ICityService _cityService;
        private readonly ICountryService _countryService;

        public PeopleController(IPeopleService peopleService, ICityService cityService, ICountryService countryService)
        {
            _peopleService = peopleService;
            _cityService = cityService;
            _countryService = countryService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_peopleService.All());
        }



        [HttpGet]
        public IActionResult Create()
        {
            CreatePersonViewModel createPerson = new CreatePersonViewModel();
            createPerson.Cities = _cityService.UniqAll();
            createPerson.CountrysList = _countryService.All();

            return View(createPerson);
        }

        [HttpPost]
        public IActionResult Create(CreatePersonViewModel createPerson)
        {
            if (ModelState.IsValid && createPerson !=null)
            {
                _peopleService.Add(createPerson);

                return RedirectToAction("Index");
            }
            createPerson.CountrysList = _countryService.All();
            createPerson.Cities = _cityService.All();

            return View(createPerson);
        }

        [HttpGet]
        public IActionResult Edit()
        {
            /*id = 10;
            Person person = _peopleService.FindById(id);
            editPerson.id = id;
            editPerson.FirstName = person.FirstName;
            editPerson.LastName = person.LastName;
            editPerson.PhoneNumber = person.PhoneNumber;
            editPerson.CityId = (int)person.CityId;
            editPerson.CityName = person.CityName;
            editPerson.CountryId = (int)_cityService.FindById((int)person.CityId).CountryId;
            editPerson.CountryName = _cityService.FindById((int)person.CityId).CountryName;*/
            CreatePersonViewModel editPerson = new CreatePersonViewModel();
            
            editPerson.Cities = _cityService.UniqAll();
            editPerson.CountrysList = _countryService.All();

            
            return View(editPerson);
        }

        [HttpPost]
        public IActionResult Edit(int id, CreatePersonViewModel createPerson)
        {
            
            Person person = _peopleService.FindById(id);
            CreatePersonViewModel editPerson = new CreatePersonViewModel();
            
            editPerson.id = id;
            editPerson.Cities = _cityService.UniqAll();
            editPerson.CountrysList = _countryService.All();
            editPerson.FirstName = person.FirstName;
            editPerson.LastName = person.LastName;
            editPerson.PhoneNumber = person.PhoneNumber;
            editPerson.CityId = (int)person.CityId;
            editPerson.CityName = person.CityName;
            editPerson.CountryId = (int)_cityService.FindById((int)person.CityId).CountryId;
            editPerson.CountryName = _cityService.FindById((int)person.CityId).CountryName;

            if (ModelState.IsValid && createPerson != null)
            {
                id = editPerson.id;
                _peopleService.Edit(id, createPerson);

                return RedirectToAction("Index");
            }
            createPerson.CountrysList = _countryService.All();
            createPerson.Cities = _cityService.All();

            return View(editPerson);
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult DeletePerson(int id)
        {
            if (ModelState.IsValid)
            {
                _peopleService.Remove(id);
               return RedirectToAction("Index");

            }
            
            return View();
        }
        
        [HttpPost]
        public IActionResult Info(int id)
        {
            if (ModelState.IsValid )
            {
                
                return View(_peopleService.FindById(id));
                
            }
            return View();
        }

        [HttpPost]
        public IActionResult Search(string textin)
        {
           
            if (ModelState.IsValid && _peopleService.Search(textin) != null)
            {
                
                return View(_peopleService.Search(textin));

            }
            return View();
        }

        

    }
}
