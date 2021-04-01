using Microsoft.AspNetCore.Mvc;
using MyMovies.Mappings;
using MyMovies.Services.Interfaces;
using MyMovies.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                    if(returnUrl == null)
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
    }
}
