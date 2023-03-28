using SpaceProgram.BusinessLayer.Interfaces;
using SpaceProgram.BusinessLayer.Managers;
using SpaceProgram.DataLayer.Interfaces;
using SpaceProgram.DataLayer.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
builder.Services.AddScoped<IOfficerManager, OfficerManager>();
builder.Services.AddScoped<IOfficerRepository, SqlServerOfficerRepository>();
builder.Services.AddScoped<ISpaceStationManager, SpaceStationManager>();
builder.Services.AddScoped<ISpaceStationRepository, SqlServerSpaceStationRepository>();
builder.Services.AddScoped<IUserManager, UserManager>();
builder.Services.AddScoped<IUserRepository, SqlServerUserRepository>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();