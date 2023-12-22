using System.Security.Claims;
using BookmateApp.DTOs.Requests;
using BookmateApp.Mvc.Extensions;
using BookmateApp.Mvc.Models;
using BookmateApp.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace BookmateApp.Mvc.Controllers
{

    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string? pageToGo)
        {
            var userLoginViewModel = new UserLoginViewModel()
            {
                PageToGo = pageToGo
            };
            return View(userLoginViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel userLogin)
        {
            if(ModelState.IsValid)
            {
                var userLoginRequest = new UserLoginRequest {
                    Username = userLogin.Username,
                    Password = userLogin.Password,
                };
                var user = await _userService.ValidateUser(userLoginRequest);
                if(user is not null)
                {
                    await HttpContext.SignInAsync(user.UserLogin());
                    if (string.IsNullOrEmpty(userLogin.PageToGo) && Url.IsLocalUrl(userLogin.PageToGo))
                    {
                        return Redirect(userLogin.PageToGo);

                    }
                    return Redirect("/");
                }
                ModelState.AddModelError("login", "Kullanıcı adı veya şifre yanlış!");
                
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
