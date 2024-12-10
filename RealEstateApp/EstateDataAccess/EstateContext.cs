using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using ModelsLibrary.Models;

namespace EstateDataAccess
{
    public class EstateContext : DbContext
    {
        public DbSet<Estate> Estates { get; set; }
        public DbSet<Residential> Residentials { get; set; }
        public DbSet<Commercial> Commercials { get; set; }
        public DbSet<Institutional> Institutionals { get; set; }
        public DbSet<Apartment> Apartment { get; set; }
        public DbSet<Villa> Villa { get; set; }
        public DbSet<Factory> Factory { get; set; }
        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<School> School { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\" +
                "MSSQLLocalDB;Initial Catalog=EstateDb;Integrated Security=True;Connect" +
                " Timeout=30;Encrypt=False;Trust Server Certificate=False;" +
                "Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estate>().ToTable("Estates");

            modelBuilder.Entity<Residential>().ToTable("Residentials");
            modelBuilder.Entity<Commercial>().ToTable("Commercials");
            modelBuilder.Entity<Institutional>().ToTable("Institutionals");

            modelBuilder.Entity<Apartment>().ToTable("Apartment");
            modelBuilder.Entity<Villa>().ToTable("Villa");

            modelBuilder.Entity<Factory>().ToTable("Factory");
            modelBuilder.Entity<Hotel>().ToTable("Hotel");

            modelBuilder.Entity<School>().ToTable("School");
        }

        public List<Estate> LegalFormEstates(LegalFormEnum value)
        {
            return Estates.Where(estate => estate.LegalForm == value).ToList();
        }


        // Deletes Estate and associated Address
        //public void DeleteFromDB(int id)
        //{
        //    Database.ExecuteSqlRaw(
        //        "DELETE FROM Address WHERE Id = (SELECT AddressId FROM Estates WHERE ID = {0}); " +
        //        "DELETE FROM Estates WHERE ID = {0};",
        //        id);

        //}

    }
}
