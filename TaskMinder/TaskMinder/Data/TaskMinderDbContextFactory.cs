using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Serilog;
using System.Diagnostics;

namespace TaskMinder.Data;

public class TaskMinderDbContextFactory : IDesignTimeDbContextFactory<TaskMinderDbContext>
{
    public TaskMinderDbContext CreateDbContext(string[] args)
    {
        // https://www.npgsql.org/efcore/release-notes/6.0.html#opting-out-of-the-new-timestamp-mapping-logic
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        var configuration = BuildConfiguration(); 

        var builder = new DbContextOptionsBuilder<TaskMinderDbContext>()
            .UseNpgsql(configuration.GetConnectionString("Default"));

        return new TaskMinderDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
