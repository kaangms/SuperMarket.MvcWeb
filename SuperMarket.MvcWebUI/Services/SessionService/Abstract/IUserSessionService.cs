using SuperMarket.MvcWebUI.Models;

namespace SuperMarket.MvcWebUI.Services.SessionService.Abstract
{
    public interface IUserSessionService
    {
        public UserViewModel GetUser();

        public void SetUser(UserViewModel userViewModel);
    }
}