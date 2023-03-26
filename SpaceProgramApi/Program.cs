using Microsoft.EntityFrameworkCore;
using SpaceProgram.DataLayer.EntityFramework;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SpaceProgramContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SpaceProgramApiContext") ?? throw new InvalidOperationException("Connection string 'SpaceProgramApiContext' not found.")));

// Add services to the container.

builder.Services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
