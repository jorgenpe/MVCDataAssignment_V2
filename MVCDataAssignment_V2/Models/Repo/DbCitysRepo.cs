using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCDataAssignment_V2.Data;

namespace MVCDataAssignment_V2.Models.Repo
{
    public class DbCitysRepo : ICitysRepo
    {
        readonly PeopleDbContext _peopleDbContext;

        public DbCitysRepo(PeopleDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }

        public City Create(City city)
        {
           
            _peopleDbContext.Add(city);
            _peopleDbContext.SaveChanges();

            return city;
        }

        public bool Delete(City city)
        {
            _peopleDbContext.Remove(city);

            int change = _peopleDbContext.SaveChanges();

            if (change == 2) { return true; }

            return false;

        }

        public List<City> Read()
        {
            if(_peopleDbContext.Citys == null)
            {
                return null;
            }
            return _peopleDbContext.Citys
                .ToList();
        }

        public List<string> UniqRead()
        {
           
            List < string > list = new List < string >();
            HashSet<string > setList = new HashSet<string>();

            if (_peopleDbContext.Citys == null)
            {
                return null;
            }
           
            foreach(City city in _peopleDbContext.Citys)
            {
                setList.Add(city.CityName);
                
            }
            list = setList.ToList();
            
            return list;
      

        }
        public City Read(int id)
        {
            if (_peopleDbContext.Citys == null)
            {
                return null;
            }
            return _peopleDbContext.Citys
                .SingleOrDefault(p => p.Id == id);

        }

        public bool Update(City city)
        {
            _peopleDbContext.Citys.Update(city);
            int change = _peopleDbContext.SaveChanges();

            if (change == 2) { return true; }

            return false;

        }
    }
}
