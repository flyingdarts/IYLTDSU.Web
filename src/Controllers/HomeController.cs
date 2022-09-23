using IYLTDSU.WebApp.Configuration;
using Microsoft.AspNetCore.Mvc;
using IYLTDSU.WebApp.Views.Home;
using Microsoft.Extensions.Options;

namespace IYLTDSU.WebApp.Controllers;

public class HomeController : Controller
{
    internal HomePageViewModel ViewModel;
    private readonly CognitoOptions _options;
    public HomeController(IOptions<CognitoOptions> options, HomePageViewModel viewModel)
    {
        _options = options.Value;
        ViewModel = viewModel;
    }

    public ActionResult Index()
    {
        return View();
    }

    [HttpGet("login")]
    public IActionResult Login([FromQuery] Guid code)
    {
        ViewBag.ClientId = _options.ClientId;
        ViewBag.ClientSecret = _options.ClientSecret;
        ViewBag.GrantType = _options.GrantType;
        ViewBag.RedirectUri = _options.RedirectUri;
        ViewBag.Code = code.ToString();
        ViewBag.MetaDataAddress = _options.MetaDataAddress;
        ViewBag.LogOutUri = _options.LogOutUri;
        return View("Index", ViewModel);
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] HomePageViewModel model)
    {
        if (ModelState.IsValid)
        {
            return RedirectToAction("Index", "Lobby");
        }
        return RedirectToAction("Index", "Error");
    }
}
