using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.core.entityframework.DbModels;

namespace webapi.core.entityframework.DAL
{
    public class DbWebApiContext : DbContext
    {
        public DbWebApiContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Business>().HasKey(m => m.Id);
            builder.Entity<Category>().HasKey(m => m.Id);

            // shadow properties
            //builder.Entity<Business>().Property<DateTime>("CreatedAt");
            //builder.Entity<Category>().Property<DateTime>("CreatedAt");

            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            updateUpdatedProperty<Business>();
            updateUpdatedProperty<Category>();

            return base.SaveChanges();
        }

        private void updateUpdatedProperty<T>() where T : class
        {
            var modifiedSourceInfo =
                ChangeTracker.Entries<T>()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entry in modifiedSourceInfo)
            {
                entry.Property("UpdatedAt").CurrentValue = DateTime.UtcNow;
            }
        }

    }
}
