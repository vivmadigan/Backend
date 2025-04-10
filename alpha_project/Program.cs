using Business.Dtos;
using Business.Factories;
using Business.Models;
using Business.Repos;
using Business.Services;
using Data.Contexts;
using Data.Enitities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<AppDbContext>(x => x
    .UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new() { Title = "alpha_project.API", Version = "v1" });
});

builder.Services.AddScoped<IClientRepo, ClientRepo>();
builder.Services.AddScoped<IProjectRepo, ProjectRepo>();
builder.Services.AddScoped<IStatusRepo, StatusRepo>();
builder.Services.AddScoped<IUserRepo, UserRepo>();

builder.Services.AddScoped<IProjectService, ProjectService>();


builder.Services.AddScoped<IMappingFactory<UserEntity, UserModel>, UserMappingFactory>();
builder.Services.AddScoped<IMappingFactory<ClientEntity, ClientModel>, ClientMappingFactory>();
builder.Services.AddScoped<IMappingFactory<StatusEntity, StatusModel>, StatusMappingFactory>();
builder.Services.AddScoped<IMappingFactory<ProjectEntity, ProjectModel>, ProjectMappingFactory>();

builder.Services.AddScoped<IFormToModelMapper<AddProjectForm, ProjectModel>, AddProjectFormMapper>();

builder.Services.AddScoped<IProjectService, ProjectService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
        options.SwaggerEndpoint("/swagger/v1/swagger.json",
            "alpha_project.API v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

app.MapControllers();

app.Run();
