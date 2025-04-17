using Business.Dtos;
using Business.Factories;
using Business.Models;
using Business.Repos;
using Business.Services;
using Data.Contexts;
using Data.Enitities;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.Local.json", optional: true, reloadOnChange: true);



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        policy.WithOrigins(
                "http://localhost:3000",
                "https://localhost:3000",
                "https://vivalpha.azurewebsites.net")   // add your deployed front‑end too
            .AllowAnyHeader()
            .AllowAnyMethod());
});


builder.Services.AddDbContext<AppDbContext>(x => x
    .UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1",
        new() { Title = "alpha_project.API", Version = "v1" });
    options.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
    {
        Description = "Paste your API key here",
        Name = "x-api-key",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id   = "ApiKey",
                    Type = ReferenceType.SecurityScheme
                }
            },
            Array.Empty<string>()
        }
    });

});

builder.Services.AddScoped<IClientRepo, ClientRepo>();
builder.Services.AddScoped<IProjectRepo, ProjectRepo>();
builder.Services.AddScoped<IStatusRepo, StatusRepo>();
builder.Services.AddScoped<IUserRepo, UserRepo>();

builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IStatusService, StatusService>();



builder.Services.AddScoped<IMappingFactory<UserEntity, UserModel>, UserMappingFactory>();
builder.Services.AddScoped<IMappingFactory<ClientEntity, ClientModel>, ClientMappingFactory>();
builder.Services.AddScoped<IMappingFactory<StatusEntity, StatusModel>, StatusMappingFactory>();
builder.Services.AddScoped<IMappingFactory<ProjectEntity, ProjectModel>, ProjectMappingFactory>();

builder.Services.AddScoped<IFormToModelMapper<AddProjectForm, ProjectModel>, AddProjectFormMapper>();
builder.Services.AddScoped<IUpdateFormMapper<UpdateProjectForm, ProjectModel>, UpdateProjectFormMapper>();


builder.Services.AddScoped<IProjectService, ProjectService>();

var app = builder.Build();

/*if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
        options.SwaggerEndpoint("/swagger/v1/swagger.json",
            "alpha_project.API v1"));
}*/

app.UseSwagger();
app.UseSwaggerUI(options =>
    options.SwaggerEndpoint("/swagger/v1/swagger.json",
        "alpha_project.API v1"));


app.UseHttpsRedirection();

app.UseCors();          
// app.UseAuthentication();  // if you add auth later
app.UseAuthorization();



app.MapControllers();

app.Run();
