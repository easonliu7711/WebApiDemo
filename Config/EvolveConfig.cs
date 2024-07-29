namespace WebApiDemo.Config;

public class EvolveConfig(string[] locations, string[] schemas)
{
    public string[] Locations { get; init; } = locations;
    public string[] Schemas { get; init; } = schemas;
}