using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCDataAssignment_V2.Models;
using MVCDataAssignment_V2.Models.ViewModels;
using MVCDataAssignment_V2.Models.Repo;

namespace MVCDataAssignment_V2.Models
{
    public interface ICityService
    {
        City Add(CreateCityViewModel City);
        List<City> All();
        List<string> UniqAll();
        List<City> Search(string search);
        City FindById(int id);
        bool Edit(int id, CreateCityViewModel city);
        bool Remove(int id);
    }
}
