using Microsoft.EntityFrameworkCore;
using PaymentService.Core.Entity;

namespace PaymentService.Core
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<Payment> Payments { get; set; }
    }
}
