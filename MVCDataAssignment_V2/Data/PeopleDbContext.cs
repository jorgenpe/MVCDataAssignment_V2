using Microsoft.EntityFrameworkCore;
using MVCDataAssignment_V2.Models;
using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MVCDataAssignment_V2.Data
{
    public class PeopleDbContext : IdentityDbContext<AccountPerson>
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
                   pl.PersonId ,
                   pl.LanguageId
               });


            modelBuilder.Entity<PersonLanguage>()
                .HasOne(pl => pl.Person)
                .WithMany(p => p.PersonLanguages)
                .HasForeignKey(pl => pl.PersonId);

            modelBuilder.Entity<PersonLanguage>()
                .HasOne(pl => pl.Language)
                .WithMany(p => p.PersonLanguages)
                .HasForeignKey(pl => pl.LanguageId);


            /*string AdminId = Guid.NewGuid().ToString();
            string AdminRoleId = Guid.NewGuid().ToString();
            string UserRoleId = Guid.NewGuid().ToString();

            modelBuilder.Entity<AccountPerson>().HasData(new AccountPerson
            {
                Id = AdminId,
                UserName = "Admin",
                Email = "admin@gmail.com",
                PasswordHash = new PasswordHasher<AccountPerson>().HashPassword(null, "Qwer€321"),
                FirstName = "Bob",
                LastName = "Hope",
                EmailConfirmed = true,
                DateOfBirth = DateTime.Now,
                AccessFailedCount = 0,
                
            });

            modelBuilder.Entity<AccountPerson>().HasData(
                new IdentityRole
                {
                    Id = AdminRoleId,
                    Name = "Admin"
                },
                new IdentityRole
                {
                    Id = UserRoleId,
                    Name = "User"
                }
                );

            modelBuilder.Entity<AccountPerson>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = AdminId,
                    RoleId = AdminRoleId
                });*/

        }


        


        /*public DbSet<Person> People { get; set; }
        public DbSet<Country> Countrys { get; set; }
        public DbSet<City> Citys { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<PersonLanguage> PersonLanguages { get; set; }*/


    }
}
