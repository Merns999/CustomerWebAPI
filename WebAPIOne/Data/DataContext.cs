using Microsoft.EntityFrameworkCore;
using WebAPIOne.DTO;

namespace WebAPIOne.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<CustomerDTO> Customers { get; set; }
    }
}
