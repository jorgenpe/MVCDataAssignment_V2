using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCDataAssignment_V2.Models;
using MVCDataAssignment_V2.Models.ViewModels;
using MVCDataAssignment_V2.Models.Repo;

namespace MVCDataAssignment_V2.Models
{
    public interface ICountryService
    {

        Country Add(CreateCountryViewModel country);
        List<Country> All();
        List<Country> Search(string search);
        Country FindById(int id);
        bool Edit(int id, CreateCountryViewModel country);
        bool Remove(int id);
    }
}
