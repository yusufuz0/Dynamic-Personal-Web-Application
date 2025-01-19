using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using DataAccesLayer.Contexts;

namespace PresentationLayer.Controllers
{
    public class SessionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string Username, string Password)
        {
            MyWebCvContext Model = new MyWebCvContext();

            var username = Model.Users.FirstOrDefault(f => f.Username == Username && f.Password == Password);

            if (username != null)
            {
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim("Id", username.Id.ToString()));
                claims.Add(new Claim("FirstName", username.FirstName));
                claims.Add(new Claim("LastName", username.LastName));
                claims.Add(new Claim(ClaimTypes.Role, username.Role.ToString()));

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                AuthenticationProperties properties = new AuthenticationProperties();
                ClaimsPrincipal principal = new ClaimsPrincipal(claimsIdentity);

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    principal, properties);

                return RedirectToAction("Index", "Home");

            }

            return View("/views/Session/Login.cshtml");
        }

        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");

        }


        [HttpGet]
        public IActionResult Register()
        {
            return View("/views/Session/Register.cshtml");

        }


        [HttpPost]
        public IActionResult Register(DataTransferObject.Response.Users data)
        {
            BusinessLayer.Session.AddUser(data);

            return RedirectToAction("Index", "Home");

        }


    }
}
