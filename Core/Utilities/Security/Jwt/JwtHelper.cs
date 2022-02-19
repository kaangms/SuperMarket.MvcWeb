using Core.Entities.Concrete;
using Core.Utilities.Security.Encyption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Core.Utilities.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }
        private TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;

        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
        }

        public AccessToken CreateToken(User user)
        {
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials);
            var jwtSecurityKeyTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityKeyTokenHandler.WriteToken(jwt);

            return new AccessToken()
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };
        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user,
            SigningCredentials signingCredentials)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                claims: SetClaims(user),
                notBefore: DateTime.Now,
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.UserData,user.Id.ToString())
            };

            return claims;
        }

        public ClaimsPrincipal CreateClaimsPrincipal(User user)
        {
            var userIdentity = new ClaimsIdentity(SetClaims(user), "Login");
            var claimsPrincipal = new ClaimsPrincipal(userIdentity);
            return claimsPrincipal;
        }
    }
}