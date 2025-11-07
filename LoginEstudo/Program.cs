using LoginEstudo.Mapper;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using ISession = NHibernate.ISession;
using LoginEstudo.Profiles;
using LoginEstudo.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// NHibernate
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

// Service
builder.Services.AddScoped<IUsuario, UsuarioService>();

// CORS - configurar antes de construir o app
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowLocalhost");
app.MapControllers();
app.Run();
