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

            dbContextOptions = new DbContextOptionsBuilder<PrototypeDbContext>()
                .UseSqlServer(configuration.GetConnectionString(connectionStringID))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .Options;
        }

        public static PrototypeDbContext CreateInstance()
        {
            if (dbContextOptions == null) return null;

            return new PrototypeDbContext(dbContextOptions);
        }
    }
}
