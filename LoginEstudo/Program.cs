
using LoginEstudo.Mapper;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using ISession = NHibernate.ISession;
using LoginEstudo.Profiles;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ISessionFactory>(factory =>
{
    string connectionString = builder.Configuration.GetConnectionString("MySql")
        ?? throw new InvalidOperationException("Connection string 'MySql' not configured.");

    return Fluently.Configure()
        .Database(MySQLConfiguration.Standard.ConnectionString(connectionString)
        .FormatSql()
        .ShowSql())
        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UsuarioMap>())
        .ExposeConfiguration(cfg =>
        {
            cfg.SetProperty("hibernate.default_lazy", "false");
        })
        .BuildSessionFactory();
});

builder.Services.AddScoped<ISession>(factory =>
{
    return factory.GetRequiredService<ISessionFactory>().OpenSession();
});



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();
