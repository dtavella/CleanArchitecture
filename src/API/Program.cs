using API.ErrorHandlerMiddleware;
using AutoMapper;
using Core.ContextProvider;
using Core.Mapper;
using Core.Repositories;
using Core.Services.Implementatios;
using Core.Services.Interfaces;
using Infrastructure;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("Audience:Secret")));
var tokenValidationParameters = new TokenValidationParameters
{
    ValidateIssuer = false,
    ValidateAudience = false,
    ValidIssuer = builder.Configuration.GetValue<string>("Audience:Iss"),
    ValidAudience = builder.Configuration.GetValue<string>("Audience:Aud"),
    ValidateLifetime = true,
    IssuerSigningKey = signingKey,
    ValidateIssuerSigningKey = true
};
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = tokenValidationParameters;
                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = ctx =>
                        {
                           return Task.CompletedTask;
                        },
                       OnTokenValidated = ctx =>
                        {
                            return Task.CompletedTask;
                        }
                    };
                });

builder.Services.AddControllers();

builder.Services.AddDbContext<DefaultContext>(q => q.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped<ProcessService>();
builder.Services.AddScoped<IFileService, FileServiceTest>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IContextProvider, JwtContextProvider>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAutheticationService, AutheticationService>();
builder.Services.AddScoped<ISecurityService, SecurityService>();

builder.Services.AddHttpContextAccessor();

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

app.UseAuthentication();
app.UseAuthorization();


app.UseHttpsRedirection();

app.MapControllers();

app.Run();
