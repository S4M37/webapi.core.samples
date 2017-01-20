using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.core.welcome.Models;

namespace webapi.core.entityframework.DBProviders
{
    public class DBBusinessContext : DbContext
    {
        public DBBusinessContext(DbContextOptions options) :base(options) 
        {

        }

        public DbSet<Business> Businesses { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Business>().HasKey(m => m.Id);
            // shadow properties
            builder.Entity<Business>().Property<DateTime>("UpdatedTimestamp");

            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            updateUpdatedProperty<Business>();

            return base.SaveChanges();
        }

        private void updateUpdatedProperty<T>() where T : class
        {
            var modifiedSourceInfo =
                ChangeTracker.Entries<T>()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entry in modifiedSourceInfo)
            {
                entry.Property("UpdatedTimestamp").CurrentValue = DateTime.UtcNow;
            }
        }
    }
}
