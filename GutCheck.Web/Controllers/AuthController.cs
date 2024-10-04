using Microsoft.AspNetCore.Mvc;
using GutCheck.Web.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using GutCheck.Core.Interfaces;
using GutCheck.Core.Types;

namespace GutCheck.Web.Controllers
{
    public class AuthController : BaseController
    {
        private IAuthService AuthService;

        public AuthController(IAuthService authService)
        {
            AuthService = authService;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = "/Tracking/Progress")
        {
            return View(new LoginViewModel { Subtitle = "Login", ReturnUrl = returnUrl });
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new BaseViewModel { Subtitle = "Register" });
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View(new BaseViewModel { Subtitle = "Access Denied" });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginModel)
        {
            AuthResult result = await AuthService.AuthenticateUser(loginModel.Username, loginModel.Password);
            if (result.IsAuthenticated)
            {
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.NameIdentifier, result.User.Id.ToString()),
                    new Claim(ClaimTypes.Name, result.User.Username),
                    new Claim(ClaimTypes.Role, result.User.Role)
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(
                    scheme: CookieAuthenticationDefaults.AuthenticationScheme,
                    principal: principal,
                    properties: new AuthenticationProperties { IsPersistent = loginModel.RememberLogin });

                return LocalRedirect(loginModel.ReturnUrl);
            }

            loginModel.Password = "";
            loginModel.Messages.AddErrors(result.Errors);
            return View(loginModel);
        }
    }
}
