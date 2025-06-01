
using System.Reflection.Metadata;
using ChatZapfy.Aplicacao.Usuarios.Profiles;
using ChatZapfy.Aplicacao.Usuarios.Servicos;
using ChatZapfy.Dominio.Usuarios.Servicos;
using ChatZapfy.Infra.Usuarios.Mapeamentos;
using ChatZapfy.Infra.Usuarios.Repositorios;
using CrystalQuartz.AspNetCore;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Dialect;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.Matchers;
using Quartz.Spi;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("MySqlConnection");

builder.Services.AddSingleton<ISessionFactory>(factory =>
{
    return Fluently.Configure()
        .Database(MySQLConfiguration.Standard.Dialect<MySQL5Dialect>().ConnectionString(connectionString))
        .Mappings(x => x.FluentMappings.AddFromAssemblyOf<UsuariosMap>())
        .BuildSessionFactory();
});

builder.Services.AddScoped<NHibernate.ISession>(factory =>
{
    var sessionFactory = factory.GetService<ISessionFactory>();
    return sessionFactory.OpenSession();
});

builder.Services.AddScoped<ITransaction>(factory =>
{
    var session = factory.GetService<NHibernate.ISession>();
    return session.BeginTransaction();
});

builder.Services.AddAuthorization();

builder.Services.AddControllers();

builder.Services.AddSingleton<IJobFactory, ScheduledJobFactory>();
builder.Services.AddSingleton<IJobListener, LogsJobListener>();



builder.Services.AddAutoMapper(typeof(UsuariosProfile));

builder.Services.Scan(scan => scan
    .FromAssemblyOf<UsuariosAppServico>()
        .AddClasses()
            .AsImplementedInterfaces()
                .WithScopedLifetime());

builder.Services.Scan(scan => scan
    .FromAssemblyOf<UsuariosServico>()
    .AddClasses()
        .AsImplementedInterfaces()
            .WithScopedLifetime());

builder.Services.Scan(scan => scan
    .FromAssemblyOf<UsuariosRepositorio>()
    .AddClasses()
        .AsImplementedInterfaces()
            .WithScopedLifetime());

var schedulerFactory = new StdSchedulerFactory();
var scheduler = schedulerFactory.GetScheduler().GetAwaiter().GetResult();
scheduler.JobFactory = builder.Services.BuildServiceProvider().GetService<IJobFactory>();

scheduler.ListenerManager.AddJobListener(builder.Services.BuildServiceProvider().GetService<IJobListener>(), GroupMatcher<JobKey>.AnyGroup());

await scheduler.ScheduleJob(faturamentosJob, TriggerBuilder.Create().WithCronSchedule("0 * * ? * *").Build());

await scheduler.Start();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseCrystalQuartz(() => scheduler);

app.UseAuthorization();

app.MapControllers();

app.Run();
