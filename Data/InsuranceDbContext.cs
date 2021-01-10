using InsuranceApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace InsuranceApp.Data
{
    public class InsuranceDbContext : DbContext
    {
        public InsuranceDbContext(ILogger<InsuranceDbContext> logger)
        {
            _logger = logger;
        }
        private string _connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=InsuranceDB;Trusted_Connection=True;MultipleActiveResultSets=true";
        private readonly ILogger<InsuranceDbContext> _logger;

        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<Person>()
                .HasOne(p => p.Contract)
                .WithOne(c => c.Person)
                .HasForeignKey<Contract>(c => c.InsuredId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _logger.LogInformation($"[DbContext] - Database start at {DateTime.Now}.");
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
