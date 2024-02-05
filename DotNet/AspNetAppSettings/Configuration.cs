//  Criando classe Configuration como estática

namespace AspNetAppSettings;

public static class Configuration
{
    public static string ApiKeyName { get; set; }

    public static string JwtKey { get; set; }

    public static bool IsEnabled { get; set; }

    public static SmtpConfiguration SmtpConfiguration { get; set; }
}

public class SmtpConfiguration
{
    public string Host { get; set; }

    public int Port { get; set; }
}