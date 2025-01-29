using System.Security.Claims;
using System.Threading.Tasks;
using BusinessApp.Repositories.Abstracts;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace BusinessApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserRepository _userRepository;

        public AuthController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity!.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {

            // Doğru kullanıcı bilgilerini kontrol et
            var login = await _userRepository.LoginAsync(email, password);

            if (login != null)
            {
                var userClaims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, login.Id.ToString()),
                        new Claim(ClaimTypes.Name, login.FullName),
                        new Claim(ClaimTypes.Email, login.Email)
                    };

                if (login.Role != null)
                {
                    userClaims.Add(new Claim(ClaimTypes.Role, login.Role.Name));
                }

                var claimsIdentity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true // Kalıcı oturum
                };

                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties
                );

                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Kullanıcı adı veya şifre yanlışsa hata mesajı ekle
                ModelState.AddModelError("", "Invalid username or password.");
            }

            // Giriş başarısızsa formu tekrar göster
            return View();
        }

        public IActionResult Signup()
        {
            if (User.Identity!.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Auth");
        }
    }
}