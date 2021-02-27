using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class RentaCarContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = (localdb)\mssqllocaldb;Database=RentaCar;Trusted_Connection = true");
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CarImage> CarImages { get; set; }




        //custom mapping (veri tabanındaki sütun isimlerini farklı class isimleriyle eşleştirmek)
        //fluent mapping
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.HasDefaultSchema("admin"); // default şemayı değiştirmek için
        //    modelBuilder.Entity<Personel>().ToTable("Employees","dbo"); //personel classının karşılığı veri tabanında employees diyerek ilişki kuruyoruz

        //    modelBuilder.Entity<Personel>().Property(p => p.Id).HasColumnName("EmployeeID"); benim yazdığım id veri tabanında EmployeeID ye denk 
        //    modelBuilder.Entity<Personel>().Property(p => p.Name).HasColumnName("FirstName");
        //    modelBuilder.Entity<Personel>().Property(p => p.Surname).HasColumnName("LastName");
        //}

    }
}
