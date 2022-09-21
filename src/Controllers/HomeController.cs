﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using IYLTDSU.WebApp.Configuration;
using IYLTDSU.WebApp.Views.Home;

namespace IYLTDSU.WebApp.Controllers;

public class HomeController : Controller
{
    private HttpClient HttpClient;
    private CognitoOptions CognitoOptions;

    public HomePageViewModel ViewModel { get; set; } = new();

    public HomeController(HttpClient httpClient, IOptions<CognitoOptions> cognitoOptions)
    {
        HttpClient = httpClient;
        HttpClient.BaseAddress = new Uri("https://auth.flyingdarts.net");

        CognitoOptions = cognitoOptions.Value;
    }
    public ActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Index([FromQuery] Guid code)
    {
        ViewBag.Code = code.ToString();
        return View("Index", ViewModel);
    }

    [HttpGet("login")]
    public ActionResult Login([FromQuery] Guid code)
    {
        var body = new FormUrlEncodedContent(
            CognitoOptions
                .ToKeyValuePairs()
                .Concat(new[]
                {
                    new KeyValuePair<string, string>("code", code.ToString())
                }));
        ViewBag.AuthBody = body;
        return View("index");
    }
}
