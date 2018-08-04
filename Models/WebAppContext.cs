using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Angular_WebApp.Models
{
    public class WebAppContext : DbContext
    {

        public WebAppContext(DbContextOptions<WebAppContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //this method is reserved for fluentAPI
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=WebApp.db");
        }
        //SaveChangesAsync method is from class at UWyo COSC4220
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            //Get all the entities we added
            var addedEntities = ChangeTracker.Entries().Where(e => e.State == EntityState.Added).ToList();
            var deletedEntities = ChangeTracker.Entries().Where(e => e.State == EntityState.Deleted).ToList();
            var editedEntities = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified).ToList();

            //populate the CreatedDate, UpdatedDate, and UserId for all new entities
            addedEntities.ForEach(e =>
            {
                e.Property("CreatedDate").CurrentValue = DateTime.Now;
            });
            //if the entities were just editied, just updated the UpdatedDate, make sure any modifications
            //to UpdatedDate and Created Date are ignored
            editedEntities.ForEach(e =>
            {
                e.Property("CreatedDate").IsModified = false;
                e.Property("UpdatedDate").CurrentValue = DateTime.Now;
                e.Property("DeletedDate").IsModified = false;
                e.Property("IsDeleted").CurrentValue = false;
            });

            //if the entities were just editied, just updated the UpdatedDate, make sure any modifications
            //to UpdatedDate and Created Date are ignored
            deletedEntities.ForEach(e =>
            {
                e.State = EntityState.Modified;
                e.Property("CreatedDate").IsModified = false;
                e.Property("UpdatedDate").CurrentValue = DateTime.Now;
                e.Property("DeletedDate").CurrentValue = DateTime.Now;
                e.Property("IsDeleted").CurrentValue = true;

            });

            return await base.SaveChangesAsync(cancellationToken);
        }


    }
}