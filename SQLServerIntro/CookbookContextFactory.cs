using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SQLServerIntro
{
    // This factory is responsible for creating our DB context. Note that
    // this will NOT BE NECESSARY anymore once we move to ASP.NET.
    public class CookbookContextFactory : IDesignTimeDbContextFactory<CookbookContext>
    {
        public CookbookContext CreateDbContext(string[]? args=null)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var optionsBuilder = new DbContextOptionsBuilder<CookbookContext>();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            return new CookbookContext(optionsBuilder.Options);
        }
    }
}
