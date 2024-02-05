using System.Reflection;

namespace Files;

public static class InternalDirectory
{
    public static string CurrentDirectory
    {
        get => Directory.GetCurrentDirectory();
    }

    public static void SetCurrent() => Directory.SetCurrentDirectory(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));

    public static string[] GetFiles(string directoryPath) => Directory.GetFiles(directoryPath);
}