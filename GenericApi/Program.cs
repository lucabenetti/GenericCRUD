using AutoMapper;
using Data.Context;
using Data.Repositories;
using GenericApplication.Requests;
using GenericApplication.Responses;
using GenericApplication.Services;
using GenericApplication.Services.Interface;
using GenericCore.Notifier;
using GenericDomain.Entities;
using GenericDomain.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<GenericDbContext>(opt => opt.UseInMemoryDatabase("GenericDbContext"));

var mapperConfig = new MapperConfiguration(config =>
{
    config.CreateMap<Person, PersonResponse>();
    config.CreateMap<PersonRequest, Person>();
});

builder.Services.AddSingleton(mapperConfig.CreateMapper());
builder.Services.AddScoped<INotifier, Notifier>();
builder.Services.AddScoped<IGenericRepository, GenericRepository>();
builder.Services.AddScoped<IGenericService, GenericService>();

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
