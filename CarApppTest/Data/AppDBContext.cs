using CarApppTest.Models;
using Microsoft.EntityFrameworkCore;

namespace CarApppTest.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
        public DbSet<Car> cars { get; set; }    
    }
}
