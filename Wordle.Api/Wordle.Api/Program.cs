using Microsoft.EntityFrameworkCore;
using Wordle.Api.Data;
using Wordle.Api.Services;

var AllOrigins = "AllOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllOrigins, policy =>
    {
        policy.WithOrigins("*");
        policy.AllowAnyMethod();
        policy.AllowAnyHeader();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Unable to connect to 'DefaultConnection'");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});
builder.Services.AddScoped<WordOfTheDayService>();
builder.Services.AddScoped<LeaderboardService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(AllOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }