using Microsoft.AspNetCore.Mvc;
using MyMovies.Mappings;
using MyMovies.Services.Interfaces;
using MyMovies.ViewModels;

namespace MyMovies.Controllers
{
    public class AuthController : Controller
    {
        private IAuthService _service { get; set; }
        public AuthController(IAuthService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignIn(SignInModel signInModel, string returnUrl)
        {

            var domainModel = signInModel.ToModel();
            if (ModelState.IsValid)
            {
                var response = _service.SignIn(domainModel.Username, domainModel.Password, signInModel.IsPersistent, HttpContext);
                if (response.Success)
                {
                    if (returnUrl == null)
                    {
                        return RedirectToAction("Overview", "Movies");
                    }
                    else
                    {
                        return Redirect(returnUrl);
                    }
                }
                else
                {
                    ModelState.AddModelError("", response.Message);
                    //return RedirectToAction("SignIn", new { ErrorMessage = response.Message });
                }
            }
            return View(signInModel);
        }
        public IActionResult SignOut()
        {
            _service.SignOut(HttpContext);
            return RedirectToAction("Overview", "Movies");
        }
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(SignUpModel signUpModel)
        {
            var domainModel = signUpModel.ToModel();
            if (ModelState.IsValid)
            {
                var response = _service.SignUp(domainModel);
                if (response.Success)
                {
                    return RedirectToAction("SignIn");
                }
                else
                {
                    ModelState.AddModelError("", response.Message);
                }
            }

            return View(signUpModel);
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
