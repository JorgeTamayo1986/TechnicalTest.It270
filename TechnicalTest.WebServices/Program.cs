using Microsoft.EntityFrameworkCore;
using TechnicalTest.Models;
using TechnicalTest.WebServices.Application;
using TechnicalTest.WebServices.Application.Contracts;
using TechnicalTest.WebServices.Domain.Contracts;
using TechnicalTest.WebServices.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inyección de la cadena de conexión al contexto
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Connection"))
);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

#region Application
builder.Services.AddScoped<IRaceAppService, RaceAppService>();
builder.Services.AddScoped<IAnimalAppService, AnimalAppService>();

#endregion

#region Domain
builder.Services.AddScoped<IRaceDomainService, RaceDomainService>();
builder.Services.AddScoped<IAnimalDomainService, AnimalDomainService>();
#endregion

var app = builder.Build();

///Solo se debe ejecutar la primera vez para crear el Modelo de BD
//using (var scope = app.Services.CreateScope())
//{

//    var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
//    context.Database.Migrate();
//}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
