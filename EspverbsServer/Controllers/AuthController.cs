using espverbs.Server.Services.AuthServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Server.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        public ActionResult Login()
        {
            return View();
        }

        // POST: Auth/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(IFormCollection collection)
        {
            try
            {
                await _authService.LoginUserWithCookiesAsync(HttpContext, collection["login"], collection["password"]);
            }
            catch (Exception e)
            {
                return StatusCode(400);
            }

            return RedirectToAction("Index", "Home");
        }

        
        [HttpGet]
        [Authorize]
        public async Task<ActionResult> Logout()
        {
            try
            {
                await _authService.LogoutUserWithCookiesAsync(HttpContext);
            }
            catch (Exception e)
            {
                return StatusCode(400);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
