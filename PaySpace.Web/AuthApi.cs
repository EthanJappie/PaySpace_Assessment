using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using PaySpace.Web.Models;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using PaySpace.Web.Authentication;

namespace PaySpace.Web
{
    public static class AuthApi
    {
        //public static RouteGroupBuilder MapAuth(this IEndpointRouteBuilder routes)
        //{
        //    var group = routes.MapGroup("/auth");

        //    group.MapPost("register", async (UserInfo userInfo, AuthClient client) =>
        //    {
        //        // Retrieve the access token given the user info
        //        var token = await client.CreateUserAsync(userInfo);

        //        if (token is null)
        //        {
        //            return Results.Unauthorized();
        //        }

        //        return SignIn(userInfo, token);
        //    });

        //    group.MapPost("login", async (UserInfo userInfo, AuthClient client) =>
        //    {
        //        // Retrieve the access token give the user info
        //        var token = await client.GetTokenAsync(userInfo);

        //        if (token is null)
        //        {
        //            return Results.Unauthorized();
        //        }

        //        return SignIn(userInfo, token);
        //    });

        //    group.MapPost("logout", async (HttpContext context) =>
        //    {
        //        await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        //    })
        //    .RequireAuthorization();

        //    return group;
        //}

        //private static IResult SignIn(UserInfo userInfo, string token)
        //{
        //    var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
        //    identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, userInfo.Username));
        //    identity.AddClaim(new Claim(ClaimTypes.Name, userInfo.Username));

        //    var properties = new AuthenticationProperties();

        //    var tokens = new[]
        //    {
        //        new AuthenticationToken { Name = "access_token", Value = token }
        //    };

        //    properties.StoreTokens(tokens);


        //    return Results.SignIn(new ClaimsPrincipal(identity),
        //        properties: properties,
        //        authenticationScheme: CookieAuthenticationDefaults.AuthenticationScheme);
        //}
    }
}
