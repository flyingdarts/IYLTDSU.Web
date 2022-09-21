using Microsoft.AspNetCore.Mvc;

namespace IYLTDSU.WebApp.Controllers;
public class LegalController : Controller
{
    public IActionResult PrivacyPolicy()
    {
        return View();
    }

    public IActionResult TermsOfService()
    {
        return View();
    }
}
