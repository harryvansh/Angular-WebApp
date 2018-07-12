using Microsoft.EntityFrameworkCore;

namespace Angular_WebApp.Models
{
    public class WebAppContext : DbContext
    {
        
        public WebAppContext(DbContextOptions<WebAppContext> options) : base (options) {}


        public DbSet<Employee> Employees {get; set;} 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=WebApp.db");
        }
    }
}