using EvolveDb;
using Npgsql;

namespace WebApiDemo.Config;

public static class EvolveConfig
{
    public static void RunEvolveMigrations(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        var evolveConfig = configuration.GetSection("Evolve").Get<EvolveSettings>();
        if (evolveConfig == null) return;
        using var connection = new NpgsqlConnection(connectionString);
        var evolve = new Evolve(connection, Console.WriteLine)
        {
            Locations = evolveConfig.Locations,
            Schemas = evolveConfig.Schemas
        };
        evolve.Migrate();
    }
}

public class EvolveSettings(string[] locations, string[] schemas)
{
    public string[] Locations { get; init; } = locations;
    public string[] Schemas { get; init; } = schemas;
}