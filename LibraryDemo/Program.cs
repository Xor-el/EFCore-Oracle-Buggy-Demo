using LibraryDemo.Data;
using LibraryDemo.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register Library Service to use it with Dependency Injection in Controllers
builder.Services.AddScoped<ILibraryService, LibraryService>();

// Register database
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection"),
       oracleOptionsAction: oracleOptions =>
       {
           oracleOptions.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName);
       }).EnableSensitiveDataLogging();
});

var app = builder.Build();

// Run Migrations
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    //db.Database.EnsureDeleted();
    //db.Database.EnsureCreated();
    db.Database.Migrate();

}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
