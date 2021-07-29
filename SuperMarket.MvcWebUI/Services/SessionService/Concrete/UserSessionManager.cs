using Microsoft.AspNetCore.Http;
using SuperMarket.MvcWebUI.Extensions;
using SuperMarket.MvcWebUI.Models;
using SuperMarket.MvcWebUI.Services.SessionService.Abstract;

namespace SuperMarket.MvcWebUI.Services.SessionService.Concrete
{
    public class UserSessionManager : IUserSessionService
    {
        private IHttpContextAccessor _httpContextAccessor;

        public UserSessionManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public UserViewModel GetUser()
        {
            UserViewModel userVewModelCheck = _httpContextAccessor.HttpContext.Session.GetObject<UserViewModel>("userVewModel");

            if (userVewModelCheck == null)
            {
                _httpContextAccessor.HttpContext.Session.SetObject("userVewModel", new UserViewModel());
                userVewModelCheck = _httpContextAccessor.HttpContext.Session.GetObject<UserViewModel>("userVewModel");
            }

            return userVewModelCheck;
        }

        public void SetUser(UserViewModel userVewModel)
        {
            _httpContextAccessor.HttpContext.Session.SetObject("userVewModel", userVewModel);
        }
    }
}