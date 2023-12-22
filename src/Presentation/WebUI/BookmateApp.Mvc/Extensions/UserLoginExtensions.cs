using BookmateApp.DTOs.Responses;
using BookmateApp.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace BookmateApp.Mvc.Extensions;

public static class UserLoginExtensions
{
    public static ClaimsPrincipal UserLogin(this UserResponse response)
    {
        IEnumerable<Claim> claims = new List<Claim>()
        {
                        new Claim(ClaimTypes.Name, response.Name),
                        new Claim(ClaimTypes.Email, response.Email),
                        new Claim(ClaimTypes.Role, response.Role)
                    };
        ClaimsIdentity claimsIdentity = new ClaimsIdentity(
            claims, CookieAuthenticationDefaults.AuthenticationScheme
        );
        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
        return claimsPrincipal;
    }
}

