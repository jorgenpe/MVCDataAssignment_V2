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
    public class LanguageController : Controller
    {

        private readonly ILanguageService _langauageService;

        public LanguageController(ILanguageService languageService)
        {
            _langauageService = languageService;
        }

        public IActionResult Index()
        {
            CreateLanguageViewModel language = new CreateLanguageViewModel();
            language.languages = _langauageService.All();
            return View(language);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateLanguageViewModel createLanguageViewModel)
        {
            if (ModelState.IsValid)
            {
                _langauageService.Add(createLanguageViewModel);
                return RedirectToAction("Index");
            }

            return View();
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            Language language = _langauageService.FindById(id);
            CreateLanguageViewModel languageViewModel = new CreateLanguageViewModel();
            languageViewModel.LanguageName = language.LanguageName;
            languageViewModel.Id = language.Id;

            return View(languageViewModel);
        }


        [HttpPost]
        public IActionResult Edit(int id, CreateLanguageViewModel editLanguage)
        {
            if (ModelState.IsValid)
            {
                _langauageService.Edit(id, editLanguage);
                return RedirectToAction("Index");
            }
            return View(editLanguage);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (_langauageService.Remove(id))
            {
                return RedirectToAction("Index");
            }
            ViewBag.Message = "Unable to delete language post";
            return View("Index", _langauageService.All());
        }

    }
}
