using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.Controllers
{
    public class InfoController : Controller
    {
        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }
        public IActionResult ErrorNotFound()
        {
            return View();
        }
        public IActionResult ActionNotSuccessful (string message)
        {
            ViewBag.Message = message;
            return View();
        }

    }
}
