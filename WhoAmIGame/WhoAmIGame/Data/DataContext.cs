using Microsoft.EntityFrameworkCore;

namespace WhoAmIGame.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
    }
}
