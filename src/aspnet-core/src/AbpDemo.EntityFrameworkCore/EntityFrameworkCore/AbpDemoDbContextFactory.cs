using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using AbpDemo.Configuration;
using AbpDemo.Web;

namespace AbpDemo.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class AbpDemoDbContextFactory : IDesignTimeDbContextFactory<AbpDemoDbContext>
    {
        public AbpDemoDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AbpDemoDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            AbpDemoDbContextConfigurer.Configure(builder, configuration.GetConnectionString(AbpDemoConsts.ConnectionStringName));

            return new AbpDemoDbContext(builder.Options);
        }
    }
}
