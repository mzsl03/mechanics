using Microsoft.EntityFrameworkCore;
using AutoSzereloMuhely.Domain;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

builder.Services.AddControllers();

//builder.Services.AddDbContext<>()

builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IUgyfelService>();
builder.Services.AddSingleton<IMunkaService>();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
