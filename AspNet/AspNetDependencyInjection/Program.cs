using AspNetDependencyInjection;
using AspNetDependencyInjection.ImplementationsExamples;
using AspNetDependencyInjection.InterfacesExamples;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

void TransientScopedSingleton()
{
    //  Transient - Sempre cria uma nova inst�ncia
    builder.Services.AddTransient<IService, ServiceOne>();

    //  Scoped - Nova inst�ncia por requisi��o
    builder.Services.AddScoped<IService, ServiceOne>();

    //  Singleton - Somente uma inst�ncia
    builder.Services.AddSingleton<IService, ServiceOne>();
}

void Add()
{
    //  Caso a abstra��o tenha mais de uma implementa��o injetada, sempre ser� retornado a �ltima registrada

    builder.Services.AddTransient<IService, ServiceOne>();
    builder.Services.AddTransient<IService, ServiceOne>();
    builder.Services.AddTransient<IService, ServiceTwo>();

    //  Retorno quando receber IService - "ServiceTwo"
    //  Retorno quando receber IEnumerable<IService - ["ServiceOne", "ServiceOne", "ServiceTwo"]
}

void TryAdd()
{
    //  TryAdd - N�o registra mais de uma implementa��o para a mesma abstra��o

    builder.Services.TryAddTransient<IService, ServiceOne>();
    builder.Services.TryAddTransient<IService, ServiceOne>();
    builder.Services.TryAddTransient<IService, ServiceTwo>();

    //  Retorno quando receber IService - "ServiceOne"
    //  Retorno quando receber IEnumerable<IService> - ["ServiceOne"]
}

void TryAddEnumerable()
{
    //  TryAddEnumerable - Permite registrar mais de uma implementa��o, mas n�o duplica implementa��es

    builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IService, ServiceOne>());
    builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IService, ServiceOne>());
    builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IService, ServiceTwo>());

    //  Retorno quando receber IService - "ServiceOne"
    //  Retorno quando receber IEnumerable<IService - ["ServiceOne", "ServiceTwo"]
}

void CreatingServiceDescriptor()
{
    //  Service Descriptor (AddTransient, Scoped e Singleton s�o wrapers deste item)

    var descriptor = new ServiceDescriptor(
        typeof(IService),
        typeof(ServiceOne),
        ServiceLifetime.Singleton);

    builder.Services.Add(descriptor);
}

void AddOptions()
{
    //  Adicionando IOptions<OptionsExample> pele Services.AddOptions
    builder.Services
        .AddOptions<OptionsExample>()
        .Configure<IConfiguration>((settings, configuration) => { configuration.GetSection(nameof(OptionsExample)).Bind(settings); });
}

void Configure() 
{
    //  Adicionando IOptions<OptionsExample> pelo Services.Configure
    builder.Services
        .Configure<OptionsExample>(builder.Configuration.GetSection(nameof(OptionsExample)));
}

void OtherCases()
{
    //  Utilizando extension methods
    builder.Services.AddDependeciesExtensions();

    //  Adicionando pela implementa��o ao inv�s da abstra��o
    builder.Services.AddTransient<ServiceOne>();
}

//  TransientScopedSingleton();
Add();
//  TryAddEnumerable();
//  CreatingServiceDescriptor();
//  OptionsAndDbContext();
//  OterCases();
//  TryAddEnumerable();
AddOptions();
//  Configure();

var app = builder.Build();

void InsideProgramCs()
{
    //  Usando GetRequiredService para resolver dependencias dentro do Program.cs
    using (var scope = app.Services.CreateScope())
    {
        var service = scope
            .ServiceProvider
            .GetRequiredService<IService>();
    }
}

//  InsideProgramCs()

app.MapControllers();

app.Run();
