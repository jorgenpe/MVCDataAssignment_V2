using System;
using System.Collections.Generic;
using MVCDataAssignment_V2.Models.ViewModels;

namespace MVCDataAssignment_V2.Models.Service
{
    public interface IPersonLanguageService
    {

        List<PersonLanguage> GetAll();
        PersonLanguage FindById(CreatePersonLanguageViewModel createPersonLanguage);
        PersonLanguage Create(CreatePersonLanguageViewModel createPersonLanguage);
        bool Delete(CreatePersonLanguageViewModel createPersonLanguage);
    }
}
