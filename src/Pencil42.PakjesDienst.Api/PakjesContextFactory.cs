using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Pencil42.PakjesDienst.Db;

namespace Pencil42.PakjesDienst.Api
{
    // this is only used for design-time commands, e.g. package manager console
    public class PakjesContextFactory : IDesignTimeDbContextFactory<PakjesContext>
    {
        public PakjesContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<PakjesContext>();

            var connectionString = configuration.GetConnectionString(Constants.ConnectionStrings.Pakjes);

            builder.UseSqlServer(connectionString);

            return new PakjesContext(builder.Options);
        }
    }
}