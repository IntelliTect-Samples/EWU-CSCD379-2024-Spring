using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using Wordle.Api;
using Wordle.Api.Identity;
using Wordle.Api.Models;
using Wordle.Api.Services;

var AllOrigins = "AllOrigins";

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<WordleDbContext>(options =>
    options.UseSqlServer(connectionString));
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();

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

builder.Services.AddScoped<WordOfTheDayService>();
builder.Services.AddScoped<GameService>();

// Identity Services
builder.Services.AddIdentityCore<AppUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<WordleDbContext>(); // Tell identity where to sstore things

// JWT Token Setup
JwtConfiguration jwtConfig = builder.Configuration
    .GetSection("Jwt").Get<JwtConfiguration>() ?? throw new InvalidOperationException("JWT config not specified");
builder.Services.AddSingleton(jwtConfig);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtConfig.Issuer,
            ValidAudience = jwtConfig.Audience,

            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Secret))
        }
    );

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<WordleDbContext>();
    db.Database.Migrate();
    await Seeder.Seed(db);
    await IdentitySeed.SeedAsync(
        scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>(),
        scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>(),
        db);
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