using Microsoft.EntityFrameworkCore;
using WhoAmIGame.Data.Models;

namespace WhoAmIGame.Data
{
    public class DataContext : DbContext
    {
        public DbSet<PlayRoom> PlayRoom { get; set; }

        public DbSet<Person> Person { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
    }
}
