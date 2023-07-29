using API.ErrorHandlerMiddleware;
using AutoMapper;
using Core.Mapper;
using Core.Repositories;
using Core.Services.Implementatios;
using Core.Services.Interfaces;
using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.AddDbContext<DefaultContext>(q => q.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped<ProcessService>();
builder.Services.AddScoped<IFileService, FileServiceTest>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddAutoMapper(typeof(MapperProfile));

var app = builder.Build();

var imapper = app.Services.GetRequiredService<IMapper>();
imapper.ConfigurationProvider.AssertConfigurationIsValid();

app.UseMiddleware<ErrorHandlerMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
