using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GolfCoueseBookingApp.Models
{
    public class MyContext : DbContext
    {
        private readonly string ConnectionString = "Data Source=localhost\\SQLEXPRESS05;database=golf_cource;Trusted_Connection=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //private readonly string ConnectionString = "Data Source=localhost\\SQLEXPRESS05;database =golf_cource;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";




        public DbSet<UserModel> User { get; set; }
        public DbSet<CourseModel> Course { get; set; }

        private static ILoggerFactory __oILoggerFactory = null;

        // .net core 2.2
        // http://thedatafarm.com/data-access/logging-in-ef-core-2-2-has-a-simpler-syntax-more-like-asp-net-core/
        private ILoggerFactory GetLoggerFactory()
        {
            if (__oILoggerFactory == null)
            {
                IServiceCollection serviceCollection = new ServiceCollection();
                serviceCollection.AddLogging(builder =>
                       builder.AddConsole()
                              //.AddProvider(this) // uncomment to send to c:\temp\sql.sql
                              // Only filter on database commands sent to the database.
                              // Remove this filter if you need more.
                              .AddFilter(DbLoggerCategory.Database.Command.Name,
                                         LogLevel.Information));
                __oILoggerFactory = serviceCollection.BuildServiceProvider()
                        .GetService<ILoggerFactory>();
            }
            return __oILoggerFactory;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(GetLoggerFactory());
            optionsBuilder.UseSqlServer(ConnectionString);
        }

    }
}