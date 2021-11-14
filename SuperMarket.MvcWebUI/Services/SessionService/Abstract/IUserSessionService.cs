using Core.Entities.Concrete;
using SuperMarket.MvcWebUI.Models;

namespace SuperMarket.MvcWebUI.Services.SessionService.Abstract
{
    public interface IUserSessionService
    {
        public User GetUser();

        public void SetUser(User user);
    }
}