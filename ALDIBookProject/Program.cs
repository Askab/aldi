using ALDIBookProject.Config.Bindings;
using ALDIBookProject.Contexts;
using ALDIBookProject.Repositories.Implementations;
using ALDIBookProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<BookDBContext>(options =>
    options.UseInMemoryDatabase("BookDatabase"));

/**
 * Bindings
 */
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

BookBindings.bind(builder.Services);
LoanBindings.bind(builder.Services);
UserBindings.bind(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
