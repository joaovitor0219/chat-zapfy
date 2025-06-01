using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Serialization;
using Amazon.SQS;
using ChatZapfy.Aplicacao.Usuarios.Profiles;
using ChatZapfy.Aplicacao.Usuarios.Servicos;
using ChatZapfy.Dominio.ConfiguracoesAws;
using ChatZapfy.Dominio.Usuarios.Servicos;
using ChatZapfy.Infra.Usuarios.Mapeamentos;
using ChatZapfy.Infra.Usuarios.Repositorios;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NHibernate;
using Amazon.Extensions.NETCore.Setup;
using ISession = NHibernate.ISession;

public class Program
{
    public Program(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var program = new Program(builder.Configuration);
        program.ConfigureServices(builder.Services);

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseRouting();

        app.UseCors(c =>
        {
            c.AllowAnyHeader();
            c.AllowAnyMethod();
            c.AllowAnyOrigin();
        });

        app.UseHttpsRedirection();
        // app.UseAuthentication();
        // app.UseAuthorization();

        app.UseEndpoints(endpoints => {
            endpoints.MapControllers();
        });

        app.Run();
    }

    public void ConfigureServices(IServiceCollection services)
    {
        // services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        //     .AddJwtBearer(options =>
        //     {
        //         options.TokenValidationParameters = new TokenValidationParameters
        //         {
        //             ValidateIssuer = true,
        //             ValidateAudience = true,
        //             ValidateLifetime = true,
        //             ValidateIssuerSigningKey = true,
        //             ValidIssuer = Configuration["Jwt:Issuer"],
        //             ValidAudience = Configuration["Jwt:Audience"],
        //             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))

        //         };
        //     });        
        services.AddControllers(options =>
        {
            options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
        }).AddJsonOptions(op =>
        {
            op.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            op.JsonSerializerOptions.PropertyNamingPolicy = null;
        });

        services.Configure<AwsConfig>(Configuration.GetSection("AwsConfig"));

        services.AddDefaultAWSOptions(Configuration.GetAWSOptions());

        services.AddAWSService<IAmazonSQS>();

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Por favor insira o token JWT assim: Bearer {seu token}",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
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
                        new string[] {}
                    }
                });
        });


        services.AddMvc();

        services.AddSingleton<ISessionFactory>(factory =>
        {
            string connectionString = Configuration.GetConnectionString("MySqlConnection");
            return Fluently.Configure()
                .Database((MySQLConfiguration.Standard.ConnectionString(connectionString)
                .FormatSql()
                .ShowSql()))
                .Mappings(x => x.FluentMappings.AddFromAssemblyOf<UsuariosMap>())
                .BuildSessionFactory();
        });

        services.AddScoped<NHibernate.ISession>(factory => factory.GetService<ISessionFactory>()!.OpenSession());
        services.AddScoped<ITransaction>(factory => factory.GetService<ISession>()!.BeginTransaction());

        services.AddAutoMapper(typeof(UsuariosProfile));

        services.Scan(scan => scan
            .FromAssemblyOf<UsuariosAppServico>()
            .AddClasses()
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        services.Scan(scan => scan
            .FromAssemblyOf<UsuariosServico>()
            .AddClasses()
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        services.Scan(scan => scan
            .FromAssemblyOf<UsuariosRepositorio>()
            .AddClasses()
            .AsImplementedInterfaces()
            .WithScopedLifetime());
    }
}

