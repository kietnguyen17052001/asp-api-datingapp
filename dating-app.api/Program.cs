using Microsoft.EntityFrameworkCore;
using dating_app.api.Data;
using dating_app.api.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using dating_app.api.Data.Seed;
using dating_app.api.Profiles;
using dating_app.api.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;
var connectionString = builder.Configuration.GetConnectionString("Default");
services.AddControllers();

services.AddCors(o =>
    o.AddPolicy("CorsPolicy", builder =>
        builder.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
services.AddDbContext<DataContext>(
    dbContextOptions => dbContextOptions
                .UseMySql(connectionString, serverVersion)
                // The following three options help with debugging, but should
                // be changed or removed for production.
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()
);

services.AddScoped<ITokenService, TokenService>();
services.AddScoped<IMemberService, MemberService>();
services.AddScoped<IAuthService, AuthService>();
services.AddScoped<IUserRepository, UserRepository>();
services.AddAutoMapper(typeof(UserMapperProfile).Assembly);
services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["TokenKey"]))
        };
    });

var app = builder.Build();
using var scope = app.Services.CreateScope();
var serviceProvider = scope.ServiceProvider;
try
{
    var context = serviceProvider.GetRequiredService<DataContext>();
    context.Database.Migrate();
    Seed.SeedUsers(context);
}
catch (Exception ex)
{
    var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "Migration failed");
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
