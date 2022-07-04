using Microsoft.IdentityModel.Tokens;
using MinimalAPICatalogo.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MinimalAPICatalogo.Services;

public class TokenService : ITokenService           
{
    public string GetToken(string key, string ussuer, string audience, UserModel user)
    {
        var claims = new[] {
            new Claim(ClaimTypes.Name,user.UserName),
            new Claim(ClaimTypes.NameIdentifier,Guid.NewGuid().ToString())
        };
        var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

        var credencials=new SigningCredentials(securitykey,SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(issuer: ussuer,
            audience: audience,
            expires: DateTime.Now.AddMinutes(10),signingCredentials:credencials);
        var tokenHandler=new JwtSecurityTokenHandler();
        var stringToken=tokenHandler.WriteToken(token);
        return stringToken; 

    }
}
