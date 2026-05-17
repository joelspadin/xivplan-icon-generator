using System.Diagnostics;

namespace XivplanIconGenerator;

internal static class ProcessHelper
{
    public static int Run(string fileName, IEnumerable<string> arguments)
    {
        using var proc = Process.Start(fileName, arguments);
        proc.WaitForExit();

        return proc.ExitCode;
    }

    public static string? Which(string fileName)
    {
        string[] values = GetPathVariable("PATH");
        string[] pathext = ["", .. GetPathVariable("PATHEXT")];

        foreach (var path in values)
        {
            foreach (var ext in pathext)
            {
                var fullPath = Path.Combine(path, Path.ChangeExtension(fileName, ext));
                if (File.Exists(fullPath))
                {
                    return fullPath;
                }
            }
        }

        return null;
    }

    private static string[] GetPathVariable(string name)
    {
        return (Environment.GetEnvironmentVariable(name) ?? "").Split(Path.PathSeparator);
    }
}
