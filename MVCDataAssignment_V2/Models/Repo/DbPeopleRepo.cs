using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCDataAssignment_V2.Data;
using Microsoft.EntityFrameworkCore;
namespace MVCDataAssignment_V2.Models.Repo
{
    public class DbPeopleRepo : IPeopleRepo
    {
        readonly PeopleDbContext _peopleDbContext;

        public DbPeopleRepo(PeopleDbContext peopleDbContext) 
        {
            _peopleDbContext = peopleDbContext; 
        }

        public Person Create(Person person)
        {
            _peopleDbContext.Add(person);
            _peopleDbContext.SaveChanges();

            return person;
        }

        public bool Delete(Person person)
        {
            _peopleDbContext.Remove(person);

            int change = _peopleDbContext.SaveChanges();

            if(change == 2) { return true; }

            return false;
            
        }

        public List<Person> Read()
        {
                       
            return _peopleDbContext.People
                .Include(b => b.CityName)
                .ThenInclude(a => a.CountryName)
                .ToList();
        }

        public Person Read(int id)
        {

            return _peopleDbContext.People
                .Include(b => b.CityName)
                .ThenInclude(a => a.CountryName)
                .SingleOrDefault(p => p.Id == id);

        }

        public bool Update(Person person)
        {
            _peopleDbContext.People.Update(person);
            int change = _peopleDbContext.SaveChanges();

            if (change == 2) { return true; }

            return false;

        }
    }
}
