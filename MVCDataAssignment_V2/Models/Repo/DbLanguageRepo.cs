using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCDataAssignment_V2.Models;
using MVCDataAssignment_V2.Data;
using Microsoft.EntityFrameworkCore;


namespace MVCDataAssignment_V2.Models.Repo
{
    public class DbLanguageRepo : ILanguageRepo
    {
        readonly PeopleDbContext _peopleDbContext;

        public DbLanguageRepo(PeopleDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }
   
        public Language Create(Language language)
        {
            _peopleDbContext.Add(language);
            _peopleDbContext.SaveChanges();
            return language;
        }

        public bool Delete(Language language)
        {
            _peopleDbContext.Remove(language);

            int change = _peopleDbContext.SaveChanges();

            if (change == 2) { return true; }

            return false;
        }

        public List<Language> Read()
        {
            return _peopleDbContext.Languages
                .Include(b => b.PersonLanguages)
                .ThenInclude(a => a.Person)
                .ToList();
        }

        public Language Read(int id)
        {
            return _peopleDbContext.Languages
                .Include(b => b.PersonLanguages)
                .ThenInclude(a => a.Person)
                .ToList()
                .SingleOrDefault(language => language.Id == id );
        }

        public bool Update(Language language)
        {
            _peopleDbContext.Languages.Update(language);
            int change = _peopleDbContext.SaveChanges();

            if (change == 2) { return true; }

            return false;
        }
    }
}
