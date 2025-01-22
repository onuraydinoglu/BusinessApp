using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BusinessApp.Models;

namespace BusinessApp.Controllers;

public class HomeController : Controller
{

    public IActionResult Index()
    {
        return View();
    }
}
