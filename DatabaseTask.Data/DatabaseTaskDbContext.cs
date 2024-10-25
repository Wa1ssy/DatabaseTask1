using DatabaseTask.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace DatabaseTask.Data
{
    public class DatabaseTaskDbContext : DbContext
    {
        public DatabaseTaskDbContext()
        {
        }

        public DatabaseTaskDbContext(DbContextOptions<DatabaseTaskDbContext> options)
            : base(options) { }

        // näide, kuidas teha, kui lisate domaini alla ühe objekti
        // migratsioonid peavad tulema siia libary-sse e TARge20.Data alla.
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<ProjectEmployee> ProjectEmployee { get; set; }
        public DbSet<Specialist> Specialist { get; set; }
        public DbSet<ProjectSpecialist> ProjectSpecialists { get; set; }
    }
}