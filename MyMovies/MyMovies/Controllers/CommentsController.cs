using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMovies.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.Controllers
{
    public class CommentsController : Controller
    {
        private ICommentsService _service { get; set; }
        public CommentsController(ICommentsService service)
        {
            _service = service;
        }
        [HttpPost]
        [Authorize]
        public IActionResult Add(string comment, int movieId, string returnUrl)
        {
            var userId = int.Parse(User.FindFirst("Id").Value);
            var response = _service.Add(comment, movieId, userId);
            if (response.Success)
            {
                return RedirectToAction("Overview", "Movies");
            }
            else
            {
                return RedirectToAction("ActionNotSuccessful", "Info", new { Message = response.Message });
            }
        }
    }
}
