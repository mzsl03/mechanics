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

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazor",
        policy => policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
});




var app = builder.Build();

app.UseCors("AllowBlazor");

if (app.Environment.IsDevelopment())
{
    
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
