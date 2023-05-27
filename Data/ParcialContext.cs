using ConsoliParcial3.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoliParcial3.Data
{
    public class ParcialContext : DbContext
    {
        public ParcialContext(DbContextOptions<ParcialContext> options) : base(options) 
        { 
        }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

    }
}
