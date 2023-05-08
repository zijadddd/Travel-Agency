using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Travel_Agency.Data;
using Travel_Agency.Services;
using Travel_Agency.Services.Implementations;
using Microsoft.IdentityModel.Tokens;
using Travel_Agency.Models.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication().AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters {
        NameClaimType = "username",
        RoleClaimType = "role"
    };
});

builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICRUDService<TravelRoute>, TravelRoutesService>();
builder.Services.AddCors();

builder.Services.AddCors(options => {
    options.AddPolicy("AuthenticationPolicy",
                  policy => {
                      policy.WithOrigins("http://localhost:5555").AllowAnyHeader().AllowAnyMethod();
                  });
    options.AddDefaultPolicy(
                  policy => {
                      policy.WithOrigins("http://localhost:5555").WithHeaders("Authorization").AllowAnyMethod();
                  });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
