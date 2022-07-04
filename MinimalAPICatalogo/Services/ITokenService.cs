using MinimalAPICatalogo.Models;

namespace MinimalAPICatalogo.Services;

public interface ITokenService
{
    string GetToken(string key,string ussuer, string audience,UserModel user);  
}
