using ConsoliParcial3.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoliParcial3.Data
{
    public class RostrosFContext : DbContext
    {
        public RostrosFContext(DbContextOptions<RostrosFContext> options) : base(options) 
        { 
        }

        public DbSet<User> Users { get; set; }
        
    }
}
