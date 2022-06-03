using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCDataAssignment_V2.Models.ViewModels;
using MVCDataAssignment_V2.Models;

namespace MVCDataAssignment_V2.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CountryController : Controller
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            this._countryService = countryService;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult City()
        {
            return View();
        }

        public IActionResult GetCity()
        {
            return PartialView("_CountryList", _countryService.All());
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateCountryViewModel createCountry = new CreateCountryViewModel();

            return View(createCountry);
        }

        [HttpPost]
        public IActionResult Create(CreateCountryViewModel createCountry)
        {
            if (ModelState.IsValid && createCountry != null)
            {
                _countryService.Add(createCountry);

                return RedirectToAction("Index");
            }

            return View(createCountry);
        }
        


        [HttpPost]
        public IActionResult Delete(int deleteId)
        {
            if (ModelState.IsValid && _countryService.FindById(deleteId) != null)
            {
                List<Country> listCountry = new List<Country>();
                listCountry.Add(_countryService.FindById(deleteId));
                _countryService.Remove(deleteId);


                return PartialView("_CountrysListThree", listCountry);
            }
            return PartialView("_CountryFailedDelete");
        }
    }
}
