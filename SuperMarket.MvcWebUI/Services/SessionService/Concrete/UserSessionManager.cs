using Core.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using SuperMarket.MvcWebUI.Extensions;
using SuperMarket.MvcWebUI.Models;
using SuperMarket.MvcWebUI.Services.SessionService.Abstract;

namespace SuperMarket.MvcWebUI.Services.SessionService.Concrete
{
    public class UserSessionManager : IUserSessionService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserSessionManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public User GetUser()
        {
            User userToCheck = _httpContextAccessor.HttpContext.Session.GetObject<User>("user");

            if (userToCheck == null)
            {
                _httpContextAccessor.HttpContext.Session.SetObject("user", new User());
                userToCheck = _httpContextAccessor.HttpContext.Session.GetObject<User>("user");
            }

            return userToCheck;
        }

        public void SetUser(User user)
        {
            _httpContextAccessor.HttpContext.Session.SetObject("user", user);
        }
    }
}