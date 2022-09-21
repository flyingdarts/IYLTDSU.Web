using IYLTDSU.WebApp.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace IYLTDSU.WebApp.Controllers;
[TypeFilter(typeof(SampleExceptionFilter))]
public class ErrorController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
