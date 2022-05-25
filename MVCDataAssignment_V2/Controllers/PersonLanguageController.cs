using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCDataAssignment_V2.Models.ViewModels;
using MVCDataAssignment_V2.Models.Service;
using MVCDataAssignment_V2.Models;

namespace MVCDataAssignment_V2.Controllers
{
    public class PersonLanguageController : Controller
    {
        private readonly IPersonLanguageService _personLanguageService;

        public PersonLanguageController(IPersonLanguageService personLanguageService)
        {
            _personLanguageService = personLanguageService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreatePersonLanguageViewModel personLanguage)
        {

            if (ModelState.IsValid)
            {
                _personLanguageService.Create(personLanguage);
                return RedirectToAction("Create","Language");
            }
            return View();
        }
    }
}
