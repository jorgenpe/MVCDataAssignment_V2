using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCDataAssignment_V2.Models;
using MVCDataAssignment_V2.Models.ViewModels;
using MVCDataAssignment_V2.Models.Repo;


namespace MVCDataAssignment_V2.Models.Service
{
    public interface ILanguageService
    {
        Language Add(CreateLanguageViewModel language);
        List<Language> All();
        List<Language> Search(string search);
        Language FindById(int id);
        bool Edit(int id, CreateLanguageViewModel langage);
        bool Remove(int id);
    }
}
