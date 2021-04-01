using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMovies.Mappings;
using MyMovies.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService _usersService;
        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }


        [Authorize]
        public IActionResult Details()
        {
            var userId = User.FindFirst("Id").Value;
            var user = _usersService.GetDetails(userId);
            if(user == null)
            {
                return RedirectToAction("ErrorNotFound", "Info");
            }
            return View(user.ToUserDetailsModel());
        }
    }
}
