using BusinessLayer.Interfaces;
using BusinessLayer.Managers;
using SpaceProgram.DataLayer.Interfaces;
using SpaceProgram.DataLayer.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
builder.Services.AddScoped<IOfficerManager, OfficerManager>();
builder.Services.AddScoped<IOfficerRepository, SqlServerOfficerRepository>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();