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
        private IUserSessionService _userSessionService;
        private IAuthService _authService;
        private ITokenHelper _tokenHelper;

        public AuthController(IAuthService authService, ITokenHelper tokenHelper, IUserSessionService userSessionService)
        {
            _authService = authService;
            _tokenHelper = tokenHelper;
            _userSessionService = userSessionService;
        }

        public IActionResult Login()
        {
            return View(new UserViewModel());
            //return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            var result = _authService.Login(user);

            if (!result.Success)
            {
                return View();
            }
            var userViewModel = new UserViewModel()
            {
                User = result.Data
            };
            _userSessionService.SetUser(userViewModel);

            await HttpContext.SignInAsync(_tokenHelper.CreateClaimsPrincipal(user));
            return RedirectToAction("Index", "Product");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Login", "Auth");
        }
    }
}