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
        public DbSet<Country> Countrys { get; set; }
        public DbSet<City> Citys { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>()
                .HasOne(ab => ab.CityName)
                .WithMany(b => b.people)
                .HasForeignKey(ba => ba.Id);

            modelBuilder.Entity<City>()
                .HasOne(ab => ab.Country)
                .WithMany(b => b.CountryCitys)
                .HasForeignKey(ba => ba.Id);
        }
    }
}
