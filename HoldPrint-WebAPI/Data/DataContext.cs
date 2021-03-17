using System.Collections.Generic;
using HoldPrint_WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HoldPrint_WebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options){}
        public DbSet<Customer> Customers { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Customer>().HasKey(c => new { c.Id });

            builder.Entity<Customer>()
                .HasData(new List<Customer>{
                    new Customer(1, "nome1", "sobrenome1", "111.222.333-45"),
                    new Customer(2, "nome2", "sobrenome2", "999.888.777-45"),
                    new Customer(3, "nome3", "sobrenome3", "652.563.452-87")
            });
        }
    }
}