using AutoSzereloMuhely.API;
using AutoSzereloMuhely.API.Services;
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
builder.Services.AddScoped<IUgyfelService, UgyfelService>();
builder.Services.AddScoped<IMunkaService, MunkaService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    //app.UseHttpsRedirection();
    app.UseSwagger();
    app.UseSwaggerUI();
}

Console.WriteLine("SQLite path: " + Path.GetFullPath("AutoSzereloMuhely.db"));

app.MapControllers();

app.Run();
