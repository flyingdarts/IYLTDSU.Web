using System.Diagnostics;
using IYLTDSU.WebApp.Models;
using IYLTDSU.WebApp.Models.Lobby;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IYLTDSU.WebApp.Controllers;

[Authorize]
public class LobbyController : Controller
{
    private readonly ILogger<HomeController> _logger;
    //private readonly HubConnection _hubConnection;
    public LobbyController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var lobbyVm = new SidebarViewModel
        {
            CurrentUser = SeedData.LobbyViewModel.CurrentUser,
            PartySettings = SeedData.LobbyViewModel.PartySettings,
            Friends = SeedData.LobbyViewModel.Friends
        };
        return View(lobbyVm);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

public sealed class HubLogger : ILogger
{
    private readonly HubLoggerConfiguration _configuration;

    public HubLogger(HubLoggerConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IDisposable BeginScope<TState>(TState state) => default!;

    public bool IsEnabled(LogLevel logLevel) => _configuration.LogLevels.ContainsKey(logLevel);

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    {
        if (IsEnabled(logLevel))
            Debug.WriteLine("Hub: event received.");
    }

    internal static HubLoggerConfiguration FlintstonesConfiguration => new()
    {
        LogLevels = new() { { LogLevel.Debug, "Ti voe te testen." }, { LogLevel.Error, "Garantie joen skuld." } }
    };
}

public class HubLoggerConfiguration
{
    public Dictionary<LogLevel, string> LogLevels { get; set; }
}
