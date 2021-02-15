using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LoadNavigationProp
{
    public class ApplicationContext : DbContext
    {
        //public DbSet<Company> Companies { get; set; }
        //public DbSet<User> Users { get; set; }
        //public DbSet<City> Cities { get; set; }
        //public DbSet<Country> Countries { get; set; }
        //public DbSet<Position> Positions { get; set; }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<CommonUser> CommonUsers { get; set; }

        public ApplicationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=RelationsLoadingDb;Trusted_Connection=True;");
            optionsBuilder.UseLazyLoadingProxies(); // enable lazy loading for reference props
        }
    }

    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }

        public List<User> Users { get; set; }
    }
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? CompanyId { get; set; }
        public Company Company { get; set; }

        public int? PositionId { get; set; }
        public Position Position { get; set; }
    }
    // должность пользователя
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }
    }
    // страна компании
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CapitalId { get; set; }
        public City Capital { get; set; }  // столица страны
        public List<Company> Companies { get; set; }
    }
    // столица страны
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Ticket {
        public int Id { get; set; }
        public string Subject { get; set; }
        public int SupporterId { get; set; }
        public virtual CommonUser Supporter { get; set; }
        //public int UserId { get; set; }
        //public virtual CommonUser User { get; set; }
    }

    [Table("GL_User")]
    public class CommonUser {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Ticket> Tickets { get; set; }
    }

    /*
     * System.InvalidOperationException: 'Unable to determine the relationship represented by navigation property 'CommonUser.Tickets' of type 'List<Ticket>'. 
     * Either manually configure the relationship, or ignore this property using the '[NotMapped]' attribute or by using 'EntityTypeBuilder.Ignore' in 'OnModelCreating'.'
     */

    /*
     * Microsoft.Data.SqlClient.SqlException: 'Introducing FOREIGN KEY constraint 'FK_Tickets_GL_User_UserId' on table 'Tickets' may cause cycles or multiple cascade paths. 
     * Specify ON DELETE NO ACTION or ON UPDATE NO ACTION, or modify other FOREIGN KEY constraints.
     * Could not create constraint or index. See previous errors.'
     */
}
