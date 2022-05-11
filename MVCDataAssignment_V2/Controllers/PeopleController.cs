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

        public PeopleController(IPeopleService peopleService)
        {
            this._peopleService = peopleService;
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
