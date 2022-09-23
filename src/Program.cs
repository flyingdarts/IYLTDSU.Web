using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore;

[assembly: ExcludeFromCodeCoverage]
public class Program
{
    public static void Main(string[] args)
    {
        BuildWebHost(args).Run();
    }

    public static IWebHost BuildWebHost(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .ConfigureAppConfiguration(x=>x.AddSystemsManager("/WebApp"))
            .Build();
}