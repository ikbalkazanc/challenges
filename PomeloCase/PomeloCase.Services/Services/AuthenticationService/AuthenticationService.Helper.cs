using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using PomeloCase.Core.Entites;
using PomeloCase.Core.Models.Base;

namespace PomeloCase.Services.Services.AuthenticationService
{
    public partial class AuthenticationService
    {

        private TokenDto CreateToken(User user)
        {
            var accessTokenExpriation = DateTime.Now.AddMinutes(_tokenOption.Value.AccessTokenExpiration);
            var securityKey = SignService.GetSymmetricSecurityKey(_tokenOption.Value.SecurityKey);
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: _tokenOption.Value.Issuer,
                expires: accessTokenExpriation,
                notBefore: DateTime.Now,
                claims: GetClaims(user, _tokenOption.Value.Audience),
                signingCredentials: signingCredentials
            );
            var handler = new JwtSecurityTokenHandler();
            var token = handler.WriteToken(jwtSecurityToken);
            var tokenDto = new TokenDto
            {
                AccessTokenExpiration = accessTokenExpriation,
                AccessToken = token
            };
            return tokenDto;
        }
        private IEnumerable<Claim> GetClaims(User user, List<String> audiences)
        {
            //email payloading to inside of jwt
            var userList = new List<Claim> {

                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(ClaimTypes.Name,user.AuthorName),
                new Claim(JwtRegisteredClaimNames.Jti,user.Id.ToString())
            };

            userList.AddRange(audiences.Select(x => new Claim(JwtRegisteredClaimNames.Aud, x)));

            return userList;
        }
    }
}
