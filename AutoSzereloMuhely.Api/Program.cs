using AutoSzereloMuhely.API;
using Microsoft.EntityFrameworkCore;
using AutoSzereloMuhely.Domain;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<DataContext>(
    options =>
    {
        options.UseSqlite(builder.Configuration.GetConnectionString("SQLite"));
    }
    );


builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IUgyfelService, UgyfelService>();
builder.Services.AddSingleton<IMunkaService, MunkaService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
