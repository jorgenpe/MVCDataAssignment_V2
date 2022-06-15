using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCDataAssignment_V2.Models;

namespace MVCDataAssignment_V2.Controllers
{
    public class AJAXPeopleController : Controller
    {
        
        private readonly IPeopleService _peopleService;
        private readonly ICityService _cityService;

        public AJAXPeopleController(IPeopleService peopleService, ICityService cityService)
        {
            _peopleService = peopleService;
            _cityService = cityService;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult AjaxPeople()
        {
            return View();
        }

        public IActionResult GetPeoples()
        {
            return PartialView("_PeoplesList", _peopleService.All());
        }

        [HttpPost]
        public IActionResult InfoById(int info)
        {
            if (ModelState.IsValid && _peopleService.FindById(info) != null)
            {
                List<Person> listPerson = new List<Person>();

                listPerson.Add(_peopleService.FindById(info));
                return PartialView("_PeoplesListTwo", listPerson);
            }
            return View();

        }

        [HttpPost]
        public IActionResult Delete(int deleteId)
        {
            if (ModelState.IsValid  && _peopleService.FindById(deleteId)!= null)
            {
                List<Person> listPerson = new List<Person>();
                listPerson.Add(_peopleService.FindById(deleteId));
                _peopleService.Remove(deleteId);


                return PartialView("_PeoplesListThree", listPerson);
            }
            return PartialView("_FailedDelete");
        }

    }
}
