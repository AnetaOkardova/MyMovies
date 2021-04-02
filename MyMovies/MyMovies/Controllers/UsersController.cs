using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMovies.Mappings;
using MyMovies.Services.Interfaces;
using MyMovies.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public IActionResult ManageOverview(string successMessage, string errorMessage)
        {
            ViewBag.SuccessMessage = successMessage;
            ViewBag.ErrorMessage = errorMessage;
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
        public IActionResult ToggleAdminRole(int id)
        {
            var response = _usersService.ToggleAdminRole(id);
            if (response.Success)
            {
                return RedirectToAction("ManageOverview", new { SuccessMessage = "User updated successfully."});
            }
            else
            {
                return RedirectToAction("ManageOverview", new { ErrorMessage = response.Message});
            }
        }
        [Authorize(Policy = "IsAdmin")]
        public IActionResult Delete(int id)
        {
            var response = _usersService.Delete(id);
            if (response.Success)
            {
                return RedirectToAction("ManageOverview", new { SuccessMessage = "User deleted successfully." });
            }
            else
            {
                return RedirectToAction("ManageOverview", new { ErrorMessage = response.Message });
            }
        }

    }
}