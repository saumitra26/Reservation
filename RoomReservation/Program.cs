using Microsoft.EntityFrameworkCore;
using RoomReservation.Application.Interfaces;
using RoomReservation.Application.Repositories;
using RoomReservation.Application.Services;
using RoomReservation.Infrastructure.Data;
using RoomReservation.Infrastructure.Repositories;
using RoomReservation.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),b=>b.MigrationsAssembly("RoomReservation.Infrastructure")));
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<IRoomRepository, RoomRepository > ();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();

// 🔴 THIS IS REQUIRED FOR CONTROLLERS
app.MapControllers();

app.Run();



