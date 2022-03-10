using CUST.API.Configuration;
using CUST.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Register Entity Framework
DatabaseConfig.Register(builder);

// Register Identity
IdentityConfig.Register(builder);

// Register Authentication
AuthenticationConfig.Register(builder);

// Register Swagger
SwaggerConfig.Register(builder);

// Register DI
RepositoryConfig.Register(builder);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Authentication & Authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
