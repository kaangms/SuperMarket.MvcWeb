using Core.Entities.Concrete;
using Core.Utilities.Security.Jwt;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.Business.Abstract;
using SuperMarket.MvcWebUI.Models;
using SuperMarket.MvcWebUI.Services.SessionService.Abstract;
using System.Threading.Tasks;

namespace SuperMarket.MvcWebUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserSessionService _userSessionService;
        private readonly IAuthService _authService;
        private readonly ITokenHelper _tokenHelper;

        public AuthController(IAuthService authService, ITokenHelper tokenHelper, IUserSessionService userSessionService)
        {
            _authService = authService;
            _tokenHelper = tokenHelper;
            _userSessionService = userSessionService;
        }

        public IActionResult Login()
        {
            return View(new UserViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            var result = _authService.Login(user);

            if (!result.Success)
            {
                return View();
            }
            _userSessionService.SetUser(result.Data);
            await HttpContext.SignInAsync(_tokenHelper.CreateClaimsPrincipal(result.Data));
            return RedirectToAction("Index", "Product");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Login", "Auth");
        }
    }
}