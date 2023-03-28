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
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();