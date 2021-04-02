using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMovies.Common.Exceptions;
using MyMovies.Mappings;
using MyMovies.Models;
using MyMovies.Services.Interfaces;
using MyMovies.ViewModels;
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
            if (user == null)
            {
                return RedirectToAction("ErrorNotFound", "Info");
            }
            return View(user.ToUserDetailsModel());
        }
        [Authorize(Policy = "IsAdmin")]
        public IActionResult ManageOverview()
        {
            var id = int.Parse(User.FindFirst("Id").Value);
            var users = _usersService.GetAllUsers();
            var usersToModify = users.Where(x => x.Id != id);
            var modelUsers = new List<ManageOverviewUsersModel>();
            foreach (var item in usersToModify)
            {
                ManageOverviewUsersModel user = item.ToManageOverviewUsersModel();
                modelUsers.Add(user);
            }
            return View(modelUsers);
        }
        [Authorize(Policy = "IsAdmin")]
        public IActionResult EditAdminRole()
        {
            var id = int.Parse(User.FindFirst("Id").Value);
            var users = _usersService.GetAllUsers();
            var usersToModify = users.Where(x => x.Id != id);
            var modelUsers = new List<ManageOverviewUsersModel>();
            foreach (var item in usersToModify)
            {
                ManageOverviewUsersModel user = item.ToManageOverviewUsersModel();
                modelUsers.Add(user);
            }
            return View(modelUsers);
        }
        
    }
}

