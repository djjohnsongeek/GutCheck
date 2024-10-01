using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using GutCheck.Web.Models;

namespace GutCheck.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(new BaseViewModel { Subtitle = "Home" });
        }

        public IActionResult Privacy()
        {
            return View(new BaseViewModel { Subtitle = "Privacy" });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
