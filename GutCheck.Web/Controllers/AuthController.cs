using Microsoft.AspNetCore.Mvc;
using GutCheck.Web.Models;
using GutCheck.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using GutCheck.Core.Entities;
using Microsoft.AspNetCore.Authentication;

namespace GutCheck.Web.Controllers
{
    public class AuthController : BaseController
    {
        private AuthService AuthService;

        public AuthController(AuthService authService)
        {
            AuthService = authService;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = "/")
        {
            return View(new LoginViewModel { Subtitle = "Login", ReturnUrl = returnUrl });
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginModel)
        {
            User user = AuthService.AuthenticateUser(loginModel.Username, loginModel.Password);

            if (user == null) return Unauthorized();

            var claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(
                scheme: CookieAuthenticationDefaults.AuthenticationScheme,
                principal: principal,
                properties: new AuthenticationProperties { IsPersistent = loginModel.RememberLogin });

            return LocalRedirect(loginModel.ReturnUrl);
        }

        public IActionResult Register()
        {
            return View(new BaseViewModel { Subtitle = "Register" });
        }
    }
}
