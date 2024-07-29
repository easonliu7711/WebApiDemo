using EvolveDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Npgsql;
using WebApiDemo.Config;
using WebApiDemo.Data;
using WebApiDemo.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IDeviceService, DeviceService>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
    // 啟用注解
    c.EnableAnnotations();
});

var app = builder.Build();

// Run Evolve migrations
RunEvolveMigrations(app.Services);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void RunEvolveMigrations(IServiceProvider serviceProvider)
{
    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
    var connectionString = configuration.GetConnectionString("DefaultConnection");

    var evolveConfig = configuration.GetSection("Evolve").Get<EvolveConfig>();
    if (evolveConfig == null) return;
    using var connection = new NpgsqlConnection(connectionString);
    var evolve = new Evolve(connection, Console.WriteLine)
    {
        Locations = evolveConfig.Locations,
        Schemas = evolveConfig.Schemas
    };
    evolve.Migrate();
}