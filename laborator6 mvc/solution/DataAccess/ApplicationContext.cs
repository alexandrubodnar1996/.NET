using System;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class ApplicationContext : DbContext
    {
        DbSet<PointOfInterest> Points { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
