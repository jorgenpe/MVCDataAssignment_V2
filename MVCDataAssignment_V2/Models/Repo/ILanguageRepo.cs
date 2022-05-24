using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCDataAssignment_V2.Models;

namespace MVCDataAssignment_V2.Models.Repo
{
    public interface ILanguageRepo
    {
        Language Create(Language language);
        List<Language> Read();
        Language Read(int id);
        bool Update(Language language);
        bool Delete(Language language);
    }
}
