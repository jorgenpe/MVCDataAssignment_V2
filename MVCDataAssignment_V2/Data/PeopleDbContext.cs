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
        public DbSet<Language> Languages { get; set; }
        public DbSet<PersonLanguage> PersonLanguages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>()
                .HasOne(a => a.CityName)
                .WithMany(b => b.people)
                .HasForeignKey(a => a.CityId);

            modelBuilder.Entity<City>()
                .HasOne(a => a.CountryName)
                .WithMany(b => b.CountryCitys)
                .HasForeignKey(a => a.CountryId);

            modelBuilder.Entity<PersonLanguage>().HasKey(pl =>
               new {
                   pl.LanguageId,
                   pl.PersonId
               });


            modelBuilder.Entity<PersonLanguage>()
                .HasOne<Person>(pl => pl.Person)
                .WithMany(p => p.PersonLanguages)
                .HasForeignKey(pl => pl.LanguageId);

            modelBuilder.Entity<PersonLanguage>()
                .HasOne<Language>(pl => pl.Language)
                .WithMany(p => p.PersonLanguages)
                .HasForeignKey(pl => pl.PersonId);

        }


    }
}
