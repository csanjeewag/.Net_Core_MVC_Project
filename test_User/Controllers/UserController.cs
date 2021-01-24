using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using test_User.Models;

namespace test_User.Controllers
{

    public class UserController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult LogOut()
        {
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
            
        }

        [HttpPost]
        public IActionResult Login(User model,string returnUrl)
        {
           
                if (model.Email == "csanjeewag@gmail.com")
                {
                    var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, "chanaka"),
                    new Claim(ClaimTypes.Role, "Admin")

                }, CookieAuthenticationDefaults.AuthenticationScheme);

                    var principal = new ClaimsPrincipal(identity);

                    var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                     HttpContext.Session.SetString("UserName", "Chanaka S");

                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                {
                    return LocalRedirect(returnUrl);
                }
                    return RedirectToAction("Index", "Student");
                }
            else
            {
                TempData["UserLoginFailed"] = "Try Again";
                return View();
            }
                
          
        }
    }
}
