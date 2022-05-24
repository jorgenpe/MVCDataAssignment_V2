using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCDataAssignment_V2.Models
{
    public class Language
    {
        [Key]
        public int Id { get; set; }
        public string LanguageName { get; set; }

        public List<PersonLanguage> PersonLanguages { get; set;}
    }
}
