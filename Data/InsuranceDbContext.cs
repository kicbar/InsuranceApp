using InsuranceApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace InsuranceApp.Data
{
    public class InsuranceDbContext : DbContext
    {
        private string _connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=InsuranceDB;Trusted_Connection=True;MultipleActiveResultSets=true";

        public DbSet<Contract> Contracts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
