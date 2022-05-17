using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCDataAssignment_V2.Data;

namespace MVCDataAssignment_V2.Models.Repo
{
    public class DbCountryRepo : ICountryRepo
    {

        readonly PeopleDbContext _peopleDbContext;

        public DbCountryRepo(PeopleDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }

        public Country Create(Country country)
        {
            _peopleDbContext.Add(country);
            _peopleDbContext.SaveChanges();

            return country;
        }

        public bool Delete(Country country)
        {
            _peopleDbContext.Remove(country);

            int change = _peopleDbContext.SaveChanges();

            if (change == 2) { return true; }

            return false;

        }

        public List<Country> Read()
        {
            return _peopleDbContext.Countrys
                .ToList();
        }

        public Country Read(int id)
        {

            return _peopleDbContext.Countrys
                .SingleOrDefault(p => p.Id == id);

        }

        public bool Update(Country country)
        {
            _peopleDbContext.Countrys.Update(country);
            int change = _peopleDbContext.SaveChanges();

            if (change == 2) { return true; }

            return false;

        }
    }
}
