using DsvSwapi.Domain.Interfaces;
using DsvSwapi.Domain.Services;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

//Add the service
builder.Services.AddScoped<IPeople, PeopleService>();
builder.Services.AddScoped<IPlanet, PlanetService>();
builder.Services.AddScoped<IFilm, FilmService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
app.UseAuthorization();

app.MapControllers();

app.Run();
