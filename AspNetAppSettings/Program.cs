var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//  B�sico
Configuration.ApiKeyName = app.Configuration.GetValue<string>("ApiKeyName");
Configuration.JwtKey = app.Configuration.GetValue<string>("JwtKey");
Configuration.IsEnabled = app.Configuration.GetValue<bool>("IsEnabled");

//  Binding
var smtp = new SmtpConfiguration();
app.Configuration.GetSection("SmtpConfiguration").Bind(smtp);
Configuration.SmtpConfiguration = smtp;

var test = app.Configuration.GetSection("Test:IsEnabled").Value;

//  Visualiza��o
app.MapGet("/", () => new
{
    ApiKeyName = Configuration.ApiKeyName,
    SmtpConfigurationHost = Configuration.SmtpConfiguration.Host
});

app.Run();