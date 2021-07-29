using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Utilities.Results;
using SuperMarket.MvcWebUI.Models;

namespace SuperMarket.MvcWebUI.Services.SessionService.Abstract
{
   public interface IUserSessionService
    {
        public UserViewModel GetUser();
        public void SetUser(UserViewModel userViewModel);
    }
}
