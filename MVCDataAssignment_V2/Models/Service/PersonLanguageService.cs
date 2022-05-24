using MVCDataAssignment_V2.Models.ViewModels;
using System.Collections.Generic;
using MVCDataAssignment_V2.Models.Repo;
using System.Linq;
using System;

namespace MVCDataAssignment_V2.Models.Service
{
    public class PersonLanguageService : IPersonLanguageService
    {
        private readonly DbPersonLanguageRepo _dbPersonLanguageRepo;

        public PersonLanguageService(DbPersonLanguageRepo dbPersonLanguageRepo)
        {
            _dbPersonLanguageRepo = dbPersonLanguageRepo;
        }

        public PersonLanguage Create(CreatePersonLanguageViewModel createPersonLanguage)
        {
            PersonLanguage personLanguage = new PersonLanguage()
            {
                PersonId = createPersonLanguage.PersonId,
                LanguageId = createPersonLanguage.LanguageId,
            };
            return personLanguage;
        }

        public bool Delete(CreatePersonLanguageViewModel deletePersonLanguage)
        {
            PersonLanguage personLanguage = _dbPersonLanguageRepo
                .ReadByLanguageId(deletePersonLanguage.LanguageId)
                .SingleOrDefault(p => p.PersonId == deletePersonLanguage.PersonId);

            if(personLanguage != null)
            {
                return _dbPersonLanguageRepo.Delete(personLanguage);
            }
            return false;
        }

        public PersonLanguage FindById(CreatePersonLanguageViewModel createPersonLanguage)
        {
            PersonLanguage personLanguage = new PersonLanguage();
            if(createPersonLanguage.LanguageId > 0)
            {

                personLanguage.Language.PersonLanguages =_dbPersonLanguageRepo.ReadByLanguageId(createPersonLanguage.LanguageId);
                return personLanguage;
           
            }else if(createPersonLanguage.PersonId > 0)
            {
                personLanguage.Person.PersonLanguages = _dbPersonLanguageRepo.ReadByLanguageId(createPersonLanguage.PersonId);
                return personLanguage;
            }
            return null;
        }

        public List<PersonLanguage> GetAll()
        {
            return _dbPersonLanguageRepo.Read();
        }
    }
}
