
using System;
using System.ComponentModel.DataAnnotations;

namespace MVCDataAssignment_V2.Models.ViewModels
{
    public class CreatePersonLanguageViewModel
    {
        [Required]
        public int LanguageId { get; set; }

        [Required]
        public int PersonId { get; set; }

    }
}
