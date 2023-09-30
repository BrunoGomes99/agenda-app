using AgendaApp.Domain.Repository.Interfaces;
using AgendaApp.Repository.Context;
using AgendaApp.Repository.Implementations;
using AgendaApp.Service.Impementations;
using AgendaApp.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using AutoMapper;
using AgendaApp.Domain.DTO;
using AgendaApp.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

#region MySQL

var connection = builder.Configuration.GetSection(key: "MySqlConnection").GetSection(key: "ConnectionString").Value;
builder.Services.AddDbContextFactory<MyDbContext>(options =>
    options.UseMySql(connection, ServerVersion.AutoDetect(connection)));

builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseMySql(connection, ServerVersion.AutoDetect(connection)));

#endregion MySQL

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region AutoMapper

var config = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<Alert, AlertDto>();
    cfg.CreateMap<AlertDto, Alert>();
});
IMapper mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(typeof(Program));

#endregion AutoMapper

builder.Services.AddTransient<IAlertTypeService, AlertTypeService>();
builder.Services.AddTransient<IAlertTypeRepository, AlertTypeRepository>();
builder.Services.AddTransient<IAlertService, AlertService>();
builder.Services.AddTransient<IAlertRepository, AlertRepository>();

#region Configure Logs

builder.Host.ConfigureLogging(builder =>
        builder.AddJsonConsole(options =>
        {
            options.IncludeScopes = true;
            options.TimestampFormat = "hh:mm:ss ";
            options.JsonWriterOptions = new JsonWriterOptions
            {
                Indented = false
            };
        }));

#endregion Configure Logs

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
    .AllowCredentials()); // allow credentials

app.UseAuthorization();

app.MapControllers();

app.Run();
