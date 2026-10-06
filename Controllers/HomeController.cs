using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using csharp_xml.Models;
using NuLua;

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
        Program.Luau.DoString("Test()");
        return View(); 
    }

    public IActionResult LuauPage()
    {
        return View(new LuauModel());
    }
    
    [HttpPost]
    public IActionResult SubmitForm(LuauModel model)
    {
        var code = model.Code;
        
        Console.WriteLine(code);

        string output;
        
        try
        {
            Program.LuauOutput.Clear();
            Program.Luau.DoString(code);
            output = Program.LuauOutput.ToString();
        }
        catch (Exception e)
        {
            output = e.ToString();
            Console.WriteLine(e.ToString());
        }

        return View("LuauPage", new LuauModel()
        {
            Code = code,
            Output = output
        });
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
