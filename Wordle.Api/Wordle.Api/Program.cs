using Microsoft.EntityFrameworkCore;
using Wordle.Api;
using Wordle.Api.Data;
using Wordle.Api.Models;
using Wordle.Api.Services;
using Wordle.Api.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Unable to connect to 'DefaultConnection'");
builder.Services.AddDbContext<WordleDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(Authorize.EliteAdmin, Authorize.EliteAdminPolicy);
    options.AddPolicy(Authorize.WordMaster, Authorize.WordMasterPolicy);
});
builder.Services.AddScoped<WordOfTheDayService>();
builder.Services.AddScoped<LeaderboardService>();
builder.Services.AddScoped<WordEditorService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<WordleDbContext>();
    db.Database.Migrate();
    Seeder.Seed(db).Wait(); // Call the seeder to seed the database
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAllOrigins");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
