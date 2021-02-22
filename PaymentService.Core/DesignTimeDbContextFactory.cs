using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PaymentService.Core
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDBContext>
    {
        public AppDBContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AppDBContext>();
            builder.UseNpgsql(@"Server=localhost;Database=PaymentDB;Port=5432;User Id=reo;Password=habakuk2:2;");
            return new AppDBContext(builder.Options);
        }
    }
}
