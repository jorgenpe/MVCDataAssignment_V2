using MVCDataAssignment_V2.Models.ViewModels;
using System.Collections.Generic;
using MVCDataAssignment_V2.Models.Repo;
using System.Linq;
using System;

namespace MVCDataAssignment_V2.Models.Service
{
    public class PersonLanguageService : IPersonLanguageService
    {
        private readonly IPersonLanguageRepo _dbPersonLanguageRepo;

        public PersonLanguageService(IPersonLanguageRepo dbPersonLanguageRepo)
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
            return _dbPersonLanguageRepo.Create(personLanguage);
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

        public PersonLanguage FindById(CreatePersonLanguageViewModel personLanguage)
        {
            PersonLanguage personLanguageId = _dbPersonLanguageRepo
                .ReadByLanguageId(personLanguage.LanguageId)
                .SingleOrDefault(p => p.PersonId == personLanguage.PersonId);
            return personLanguageId;
        }

        public List<PersonLanguage> GetAll()
        {
            return _dbPersonLanguageRepo.Read();
        }
    }
}
