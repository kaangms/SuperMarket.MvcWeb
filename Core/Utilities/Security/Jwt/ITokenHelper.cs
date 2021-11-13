using Core.Entities.Concrete;
using System.Security.Claims;

namespace Core.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user);

        ClaimsPrincipal CreateClaimsPrincipal(User user);
    }
}