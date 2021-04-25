using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMovies.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.Controllers
{
    [Authorize]
    public class MovieLikesController : Controller
    {
        private readonly IMovieLikesService _movieLikesService;

        public MovieLikesController(IMovieLikesService movieLikesService)
        {
            _movieLikesService = movieLikesService;
        }
        public IActionResult Add(int Id)
        {
            var userId = int.Parse(User.FindFirst("Id").Value);
            var movieId = Id;
            _movieLikesService.Add(movieId, userId);
            return RedirectToAction("Overview", "Movies");
        }
        public IActionResult Remove(int Id)
        {
            var userId = int.Parse(User.FindFirst("Id").Value);
            var movieId = Id;
            _movieLikesService.Remove(movieId, userId);
            return RedirectToAction("Overview", "Movies");
        }
    }
}
