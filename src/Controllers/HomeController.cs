using Microsoft.AspNetCore.Mvc;
using IYLTDSU.WebApp.Views.Home;

namespace IYLTDSU.WebApp.Controllers;

public class HomeController : Controller
{
    public HomePageViewModel ViewModel { get; set; } = new();

    public ActionResult Index()
    {
        return View();
    }

    [HttpGet("login")]
    public IActionResult Login([FromQuery] Guid code)
    {
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
