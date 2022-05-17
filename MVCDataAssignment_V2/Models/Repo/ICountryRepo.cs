using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCDataAssignment_V2.Models;

namespace MVCDataAssignment_V2.Models
{
    public interface ICountryRepo
    {
        Country Create(Country country);
        List<Country> Read();
        Country Read(int id);
        bool Update(Country country);
        bool Delete(Country country);
    }
}
