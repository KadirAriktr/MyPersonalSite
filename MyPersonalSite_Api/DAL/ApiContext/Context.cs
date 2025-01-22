using Microsoft.EntityFrameworkCore;
using MyPersonalSite_Api.DAL.Entity;

namespace MyPersonalSite_Api.DAL.ApiContext
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=KADIR\\SQLEXPRESS;database=CoreProjeDB2;integrated security=true;TrustServerCertificate=True");

        }

        public DbSet<Category> Categories { get; set; }
    }
}
