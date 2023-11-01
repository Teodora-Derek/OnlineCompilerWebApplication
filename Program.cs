using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OnlineCompilerWebApplication.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Xml.Linq;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connetionString = builder.Configuration.GetConnectionString("DbConn");
builder.Services.AddDbContextPool<StudentContext>(
        options => options.UseMySql(connetionString, ServerVersion.AutoDetect(connetionString))
    );

var app = builder.Build();

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
