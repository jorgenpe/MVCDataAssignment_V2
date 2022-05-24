using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCDataAssignment_V2.Data;

namespace MVCDataAssignment_V2.Models.Repo
{
    public interface IPersonLanguageRepo
    {

        PersonLanguage Create(PersonLanguage personLanguage);
        List<PersonLanguage> Read();
        List<PersonLanguage> ReadByPersonId(int id);
        List<PersonLanguage> ReadByLanguageId(int id);
        bool Update(PersonLanguage personLanguage);
        bool Delete(PersonLanguage personLanguage); 
    }
}
