using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace ProyectoSO.EntityFrameworkCore
{
    public static class ProyectoSODbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<ProyectoSODbContext> builder, string connectionString)
        {
            builder.UseNpgsql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<ProyectoSODbContext> builder, DbConnection connection)
        {
            builder.UseNpgsql(connection);
        }
    }
}
