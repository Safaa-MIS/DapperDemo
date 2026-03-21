using DapperDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace DapperDemo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Company>().Ignore(c => c.Employees);
            modelBuilder.Entity<Employee>().HasOne(e => e.Company).WithMany(c => c.Employees).HasForeignKey(e => e.CompanyId);
          
        }
    }
}