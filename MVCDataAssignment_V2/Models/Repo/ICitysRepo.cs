using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCDataAssignment_V2.Models;

namespace MVCDataAssignment_V2.Models
{
    public interface ICitysRepo
    {
        City Create(City city);
        List<City> Read();
        List<string> UniqRead();
        City Read(int id);
        bool Update(City city);
        bool Delete(City city);
    }
}
