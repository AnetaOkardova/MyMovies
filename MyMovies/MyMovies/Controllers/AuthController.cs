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
        public IActionResult SignIn(SignInModel signInModel)
        {

            var domainModel = signInModel.ToModel();
            if (ModelState.IsValid)
            {
               var response = _service.GetUserByUsername(domainModel.Username, domainModel.Password);
                if (response.Success)
                {
                    return RedirectToAction("Overview");
                }
                else
                {
                    return RedirectToAction("SignIn", new { ErrorMessage = response.Message });
                }
            }
            return View(signInModel);
        }
    }
}
