using AutoMapper;
using Company.Common.DTOs;
using Company.Data.Contexts;
using Company.Data.Entities;
using Company.Data.Interfaces;
using Company.Data.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CompanyContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("CompanyConnection")));

ConfigAutoMapper(builder.Services);
RegisteredServices(builder.Services);

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

void ConfigAutoMapper(IServiceCollection services)
{
    var config = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<Organisation, OrganisationDTO>().ReverseMap();
        cfg.CreateMap<Department, DepartmentDTO>().ReverseMap();
        cfg.CreateMap<Employee, EmployeeDTO>().ReverseMap();
        cfg.CreateMap<JobTitle, JobTitleDTO>().ReverseMap();
        cfg.CreateMap<EmployeesJobTitle, EmployeesJobTitleDTO>().ReverseMap();
    });
    var mapper = config.CreateMapper();
    services.AddSingleton(mapper);
}
void RegisteredServices(IServiceCollection services)
{
    services.AddScoped<IDbService, DbService>();
}