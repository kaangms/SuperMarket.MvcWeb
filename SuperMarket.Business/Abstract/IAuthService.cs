using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;

namespace SuperMarket.Business.Abstract
{
   public interface IAuthService
   {
       IDataResult<User> Login(User user);
       IDataResult<AccessToken> CreateAccessToken(User user);
   }
}
