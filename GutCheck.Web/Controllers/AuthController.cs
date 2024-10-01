using Microsoft.AspNetCore.Mvc;
using GutCheck.Web.Models;

namespace GutCheck.Web.Controllers
{
    public class AuthController : BaseController
    {
        public IActionResult Login()
        {
            return View(new BaseViewModel { Subtitle = "Login" });
        }

        public IActionResult Register()
        {
            return View(new BaseViewModel { Subtitle = "Register" });
        }
    }
}
