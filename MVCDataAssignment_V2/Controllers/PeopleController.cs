using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            this._peopleService = peopleService;
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
            createPerson.Cities = _cityService.All();
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


        /*[HttpPut]
        public IActionResult Edit(int id,CreatePersonViewModel createPerson)
        {
            return View(createPerson);
        }*/

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
