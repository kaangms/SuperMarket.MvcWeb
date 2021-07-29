using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using SuperMarket.Business.Abstract;
using SuperMarket.Business.Constants;

namespace SuperMarket.Business.Concrete
{
  public  class AuthManager:IAuthService
  {
      private readonly IUserService _userService;
      private readonly ITokenHelper _tokenHelper;

      public AuthManager(IUserService userService, ITokenHelper tokenHelper)
      {
          _userService = userService;
          _tokenHelper = tokenHelper;
      }

      public IDataResult<User> Login(User user)
      {

          var userToCheck = _userService.GetByUser(user.UserName,user.Password);
        
          if (!userToCheck.Success)
          {
              return new ErrorDataResult<User>(Messages.UserNameOrPaswordError);
          }
          
        return new SuccessDataResult<User>(userToCheck.Data,Messages.LoginActionSuccess);

      }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
         return  new SuccessDataResult<AccessToken>(_tokenHelper.CreateToken(user)); 
        }
    }
}
