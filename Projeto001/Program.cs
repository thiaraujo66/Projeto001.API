using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Projeto001.Application.Services;
using Projeto001.Domain.Interfaces.Repositories;
using Projeto001.Domain.Interfaces.Services;
using Projeto001.Infraestrutura.Data;
using Projeto001.Infraestrutura.Repositories;
using Projeto001.Mapping.UsuarioMapping;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddDbContext<Projeto001Context>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

ConfigureJWTApplication(builder);
ConfigureSwagerAuth(builder);
ConfigureAutoMapper(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.MapGet("/", context =>
    {
        context.Response.Redirect("/swagger");
        return Task.CompletedTask;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

#region [ Métodos ]

static void ConfigureAutoMapper(WebApplicationBuilder builder) 
{
    builder.Services.AddAutoMapper(typeof(UsuarioMapping));
}

static void ConfigureJWTApplication(WebApplicationBuilder builder)
{
    var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

    var key = Encoding.ASCII.GetBytes(configuration.GetValue<string>("SecretJWT"));

    builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
}

static void ConfigureSwagerAuth(WebApplicationBuilder builder)
{
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new() { Title = "API", Version = "v1" });
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Description =
                "JWT Authorization Header - utilizado com Bearer Authentication.\r\n\r\n" +
                "Digite 'Bearer' [espaço] e então seu token no campo abaixo.\r\n\r\n" +
                "Exemplo (informar sem as aspas): 'Bearer 12345abcdef'",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
            BearerFormat = "JWT",
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                Array.Empty<string>()
            }
        });
    });
}

#endregion