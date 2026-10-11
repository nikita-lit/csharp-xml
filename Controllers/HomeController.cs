using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using csharp_xml.Models;

namespace csharp_xml.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult ElisavetaSugupuu()
    {
        return View();
    }
    
    public IActionResult Contact()
    {
        return View();
    }    
    
    public IActionResult XMLskeem()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
