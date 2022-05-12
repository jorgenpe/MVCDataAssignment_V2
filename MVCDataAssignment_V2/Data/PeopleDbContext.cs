using Microsoft.EntityFrameworkCore;
using MVCDataAssignment_V2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MVCDataAssignment_V2.Data
{
    public class PeopleDbContext : DbContext
    {
        public PeopleDbContext(DbContextOptions<PeopleDbContext> options) : base(options)
        {
           

        } 

        public DbSet<Person> People { get; set; }
        
    }
}
