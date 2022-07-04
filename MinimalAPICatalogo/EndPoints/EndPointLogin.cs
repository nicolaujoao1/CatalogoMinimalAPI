using Microsoft.AspNetCore.Authorization;
using MinimalAPICatalogo.Models;
using MinimalAPICatalogo.Services;

namespace MinimalAPICatalogo.EndPoints
{
    public static class EndPointLogin
    {
        public static void MapEndPointLogin(this WebApplication app)
        {

            //ENDPOINT PARA LOGIN 
            app.MapPost("/login", [AllowAnonymous] (UserModel? userModel, ITokenService tokenService) =>
            {
                if (userModel is null)
                    return Results.BadRequest("Login Invalido");
                if (userModel.UserName.Equals("Nicolau") && userModel.Password.Equals("1234"))
                {
                    var tokenString = tokenService.GetToken(app.Configuration["Jwt:Key"],
                        app.Configuration["Jwt:Issuer"],
                        app.Configuration["Jwt:Audience"], userModel
                        );
                    return Results.Ok(new { token = tokenString });
                }
                else
                {
                    return Results.BadRequest("Login Invalido");
                }
            }).Produces(StatusCodes.Status400BadRequest).
                Produces(StatusCodes.Status200OK).WithName("Login").WithTags("Autenticacao");

        }
    }
}
