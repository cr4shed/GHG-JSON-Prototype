using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JsonPrototype.Data.Models;
using Newtonsoft.Json;
using System.Data;
using System.Globalization;
using System.Diagnostics;

namespace JsonPrototype.Data
{
    public class PrototypeDbContext : DbContext
    {
        public static readonly ILoggerFactory EFLogger = LoggerFactory.Create(builder => { builder.AddDebug(); });

        public PrototypeDbContext (DbContextOptions<PrototypeDbContext> options) : base(options) { }

        public DbSet<Report> Reports { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Example advanced JSON settings.
            JsonSerializerSettings exampleAdvancedSettings = new()
            {
                // For more details:
                // https://learn.microsoft.com/en-us/dotnet/api/system.text.json.jsonserializeroptions?view=net-8.0
                // https://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_JsonSerializerSettings.htm
                TypeNameHandling = TypeNameHandling.Auto,
                NullValueHandling = NullValueHandling.Ignore,
                Culture = CultureInfo.CurrentCulture,
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                DateFormatString = "yyyy'-'MM'-'dd'",
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
            };

            // JSON settings.
            JsonSerializerSettings defaultSettings = new()
            {
                TypeNameHandling = TypeNameHandling.Auto
            };

            modelBuilder.Entity<Report>().ToTable("Reports");
            
            // Set auto incrementing primary key.
            modelBuilder.Entity<Report>().Property(r => r.ReportId)
                .ValueGeneratedOnAdd(); 

            // Define the JSON conversion serialization and deserialization settings.
            modelBuilder.Entity<Report>().Property(r => r.Activities)
                .HasConversion(
                    v => JsonConvert.SerializeObject(v, defaultSettings),
                    v => JsonConvert.DeserializeObject<Dictionary<string, BaseActivity>>(v, defaultSettings)
                );
        }

        public static DbContextOptions<PrototypeDbContext> EFCoreSetup(DbContextOptionsBuilder options, string connectionString)
        {
            options.UseLoggerFactory(EFLogger);
            options.EnableSensitiveDataLogging();
            options.UseSqlServer(connectionString);

            return (DbContextOptions<PrototypeDbContext>)options.Options;
        }
    }
}
