using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCDataAssignment_V2.Models.ViewModels;
using MVCDataAssignment_V2.Models.Repo;

namespace MVCDataAssignment_V2.Models.Service
{
    public class LanguageService : ILanguageService
    {
        private readonly ILanguageRepo _languageRepo;
        

        public LanguageService(ILanguageRepo languageRepo)
        {
            _languageRepo = languageRepo;
            
        }


        public Language Add(CreateLanguageViewModel addlanguage)
        {
            Language language = new Language() { LanguageName = addlanguage.LanguageName };

            
            return _languageRepo.Create(language);
            
        }

        public List<Language> All()
        {
            return _languageRepo.Read();
        }

        public List<Language> Search(string search)
        {
            List<Language> languages = new List<Language>();

            foreach(Language language in _languageRepo.Read()) 
            {
                if(language.LanguageName == search)
                {
                    languages.Add(language);
                }
                
            }
            return languages;


        }

        public Language FindById(int id)
        {
            return _languageRepo.Read(id);
        }

        public bool Edit(int id, CreateLanguageViewModel langage)
        {
            Language language = _languageRepo.Read(id);

            if(langage != null)
            {
                language.LanguageName = langage.LanguageName;
                return _languageRepo.Update(language);
                
            }
            return false;
        }

        public bool Remove(int id)
        {
            Language language = _languageRepo.Read(id); 

            if(language != null)
            {
               return _languageRepo.Delete(language);
            }

            return false;
        }

        
    }
}
