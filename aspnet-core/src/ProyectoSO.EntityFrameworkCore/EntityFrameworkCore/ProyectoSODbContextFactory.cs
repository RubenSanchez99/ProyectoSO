using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using ProyectoSO.Configuration;
using ProyectoSO.Web;

namespace ProyectoSO.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class ProyectoSODbContextFactory : IDesignTimeDbContextFactory<ProyectoSODbContext>
    {
        public ProyectoSODbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ProyectoSODbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            ProyectoSODbContextConfigurer.Configure(builder, configuration.GetConnectionString(ProyectoSOConsts.ConnectionStringName));

            return new ProyectoSODbContext(builder.Options);
        }
    }
}
