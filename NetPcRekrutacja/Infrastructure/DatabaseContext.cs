using System.Collections.Generic;
using System.Reflection.Emit;
using System.Reflection;
using NetPcRekrutacjaBackend.Domain.Employee;
using Microsoft.EntityFrameworkCore;

namespace NetPcRekrutacjaBackend.Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            new EmployeeEntityConfiguration().Configure(builder.Entity<Employee>());
        }
    }
}
