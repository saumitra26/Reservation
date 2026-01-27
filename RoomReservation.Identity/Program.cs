using Microsoft.EntityFrameworkCore;
using RoomReservation.Identity.Application;
using RoomReservation.Identity.Application.Interface;
using RoomReservation.Identity.Application.Service;
using RoomReservation.Identity.Infrastructure.Data;
using RoomReservation.Identity.Infrastructure.Repositories;
using RoomReservation.Identity.Infrastructure.Security;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<IdentityDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityDb")));
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IJwtGenerateToken, JwtGenerateToken>();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

