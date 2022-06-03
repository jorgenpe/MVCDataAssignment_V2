using System;
using Microsoft.AspNetCore.Identity;



namespace MVCDataAssignment_V2.Models
{
    
    public class AccountPerson : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public string EMail { get; set; }
        //public string Username { get; set; }    
        public DateTime DateOfBirth { get; set; }
    }
  
}
