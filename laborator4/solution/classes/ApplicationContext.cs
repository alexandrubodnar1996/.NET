using System;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;


namespace classes
{
    public class ApplicationContext : DbContext
    {

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }


        public ApplicationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Customer>(
                customer =>customer.Property( c => c.Name)
                .IsRequired()
                .HasMaxLength(100));

            model.Entity<Customer>(
                customer => customer.Property(c => c.Address)
                .IsRequired()
                .HasMaxLength(300));

            model.Entity<Customer>(
                customer => customer.Property(c => c.PhoneNumber)
                .IsRequired()
                );

            model.Entity<Customer>(
                customer => customer.Property(c => c.Email)
                .IsRequired()
                );
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("User ID = postgres; Password =1234; Server = localhost; Port = 5432; Database = unapeDbContext; Pooling = true;");
            }
        }
    }
}
