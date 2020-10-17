using Microsoft.EntityFrameworkCore;
using guard.Core.Models;
using guard.Data.Configurations;

namespace guard.Data
{
    public class GuardDBContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public GuardDBContext(DbContextOptions<GuardDBContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new EmployeeConfiguration());
        }

        
    }
}