using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCDataAssignment.Models;
namespace MVCDataAssignment.Controllers
{
    public class PeopleController : Controller
    {
        IPeopleService _peopleService;

        public PeopleController()
        {
            _peopleService = new PeopleService();
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
            if (ModelState.IsValid)
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
            if (ModelState.IsValid)
            {
                
                return View(_peopleService.FindById(id));
                
            }
            return View();
        }

        [HttpPost]
        public IActionResult Search(string textin)
        {
           
            if (ModelState.IsValid)
            {
                
                return View(_peopleService.Search(textin));

            }
            return View();
        }

        

    }
}
