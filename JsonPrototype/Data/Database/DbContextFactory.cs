using Microsoft.EntityFrameworkCore;

namespace JsonPrototype.Data
{
    public class DbContextFactory
    {
        private static DbContextOptions<PrototypeDbContext> dbContextOptions = null;

        public static void SetConnectionString(string connectionStringID)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            dbContextOptions = PrototypeDbContext.EFCoreSetup(new DbContextOptionsBuilder<PrototypeDbContext>(), configuration.GetConnectionString(connectionStringID));
        }

        public static PrototypeDbContext CreateInstance()
        {
            if (dbContextOptions == null) return null;

            return new PrototypeDbContext(dbContextOptions);
        }
    }
}
