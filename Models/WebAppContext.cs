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

        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=WebApp.db");
        }
        //SaveChangesAsync method is from class at UWyo COSC4220
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            //Get all the entities we added
            var addedEntities = ChangeTracker.Entries().Where(e => e.State == EntityState.Added).ToList();

            //populate the CreatedDate, UpdatedDate, and UserId for all new entities
            addedEntities.ForEach(e =>
            {
                if (e.Entity.GetType().GetProperty("CreatedDate") != null)
                {
                    e.Property("CreatedDate").CurrentValue = DateTime.Now;
                }
            });


            var editedEntities = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified).ToList();

            //if the entities were just editied, just updated the UpdatedDate, make sure any modifications
            //to UpdatedDate and Created Date are ignored
            editedEntities.ForEach(e =>
            {
                if (e.Entity.GetType().GetProperty("UpdatedDate") != null)
                {
                    e.Property("UpdatedDate").CurrentValue = DateTime.Now;
                }
            });

            var deletedEntities = ChangeTracker.Entries().Where(e => e.State == EntityState.Deleted).ToList();

            //if the entities were just editied, just updated the UpdatedDate, make sure any modifications
            //to UpdatedDate and Created Date are ignored
            deletedEntities.ForEach(e =>
            {
                if (e.Entity.GetType().GetProperty("DeletedDate") != null)
                {
                    e.Property("DeletedDate").CurrentValue = DateTime.Now;
                    e.Property("IsDeleted").CurrentValue = true;
                    e.State = EntityState.Unchanged;
                }
            });


            return await base.SaveChangesAsync(cancellationToken);
        }


    }
}