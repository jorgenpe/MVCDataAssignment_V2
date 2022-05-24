using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCDataAssignment_V2.Data;

namespace MVCDataAssignment_V2.Models.Repo
{
    public class DbPersonLanguageRepo : IPersonLanguageRepo
    {
        private readonly PeopleDbContext _peopleDbContext;

        public DbPersonLanguageRepo(PeopleDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }

        public PersonLanguage Create(PersonLanguage personLanguage)
        {
            _peopleDbContext.PersonLanguages.Add(personLanguage);
            _peopleDbContext.SaveChanges();
            return personLanguage;

        }

        public bool Delete(PersonLanguage personLanguage)
        {
            _peopleDbContext.PersonLanguages.Remove(personLanguage);
            return _peopleDbContext.SaveChanges() > 0;
        }

        public List<PersonLanguage> Read()
        {
            return _peopleDbContext.PersonLanguages.ToList();
        }

        public List<PersonLanguage> ReadByPersonId(int id)
        {
            return _peopleDbContext.PersonLanguages
                .Where(pl => pl.PersonId == id)
                .ToList();
        }

        public List<PersonLanguage> ReadByLanguageId(int id)
        {
            return _peopleDbContext.PersonLanguages
                .Where(pl => pl.LanguageId == id)
                .ToList();
        }

        public bool Update(PersonLanguage personLanguage)
        {
            _peopleDbContext.PersonLanguages.Update(personLanguage);
            return _peopleDbContext.SaveChanges() > 0;
        }
    }
}
