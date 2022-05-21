using Microsoft.EntityFrameworkCore;
using PensionerDetail.Entities;

namespace PensionerDetail.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<PensionerDetails> Pensioners { get; set; }
    }
}
