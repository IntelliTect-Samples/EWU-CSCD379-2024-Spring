using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Wordle.Api.Identity;
using Wordle.Api.Models;
using Wordle.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
const string AllOrigins = "AllowAllOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllOrigins, policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config =>
{
    config.SwaggerDoc("v1", new OpenApiInfo { Title = "Wordle API", Version = "v1" });
    config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });
    config.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new List<string>()
        }
    });
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
                      ?? throw new InvalidOperationException("Unable to connect to 'DefaultConnection'");

builder.Services.AddDbContext<WordleDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

// Add Identity
builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<WordleDbContext>()
    .AddDefaultTokenProviders();

// Configure Identity options
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.User.RequireUniqueEmail = true;
});

// JWT Token Setup
var jwtConfig = builder.Configuration
    .GetSection("Jwt").Get<JwtConfiguration>() ?? throw new InvalidOperationException("JWT config not specified");
builder.Services.AddSingleton(jwtConfig);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtConfig.Issuer,
        ValidAudience = jwtConfig.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Secret ?? throw new InvalidOperationException("JWT Key is missing")))
    };
});

// Add Policies
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(Authorize.EliteAdmin, Authorize.EliteAdminPolicy);
    options.AddPolicy(Authorize.MasterOfTheUniverse, Authorize.MasterOfTheUniversePolicy);
});

builder.Services.AddScoped<WordOfTheDayService>();
builder.Services.AddScoped<LeaderboardService>();
builder.Services.AddScoped<WordEditorService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<WordleDbContext>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    db.Database.Migrate();

    await IdentitySeed.SeedAsync(userManager, roleManager, db);

    // Call the Seeder to seed the database with initial words
    await Wordle.Api.Seeder.SeedAsync(db);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Ensure UseCors is called before UseAuthentication and UseAuthorization
app.UseCors(AllOrigins);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
