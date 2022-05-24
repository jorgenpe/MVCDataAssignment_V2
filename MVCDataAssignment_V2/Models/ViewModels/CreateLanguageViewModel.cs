using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MVCDataAssignment_V2.Models;


namespace MVCDataAssignment_V2.Models.ViewModels
{
    public class CreateLanguageViewModel
    {
        public int Id { get; set;}
        [Required]
        [StringLength(512)]
        public string LanguageName { get; set;}

        public int? PersonId { get; set;}
    }
}
