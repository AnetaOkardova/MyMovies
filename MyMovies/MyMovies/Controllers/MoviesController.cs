using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMovies.Common.Exceptions;
using MyMovies.Mappings;
using MyMovies.Models;
using MyMovies.Services;
using MyMovies.Services.Interfaces;
using MyMovies.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.Controllers
{
    [Authorize]
    public class MoviesController : Controller
    {
        private IMoviesService _service { get; set; }
        public MoviesController(IMoviesService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public IActionResult Overview(string title)
        {
            try
            {
                var movies = _service.GetMoviesByTitle(title);
                return View(movies);
            }
            catch (MoviesException ex)
            {
                return RedirectToAction("ActionNotSuccessful", "Info", new { Message = ex.Message });
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorNotFound", "Info");
            }

        }
        public IActionResult ManageOverview(string successMessage, string errorMessage)
        {
            try
            {
                var movies = _service.GetAllMovies();
                if (movies.Count == 0)
                {
                    ViewBag.Message = $"There are no movies to show at this time.";
                }
                ViewBag.SuccessMessage = successMessage;
                ViewBag.ErrorMessage = errorMessage;
                return View(movies);
            }
            catch (MoviesException ex)
            {
                return RedirectToAction("ActionNotSuccessful", "Info", new { Message = ex.Message });
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorNotFound", "Info");
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateMovieModel movieModel)
        {
            var domainModel = movieModel.ToModel();
            if (ModelState.IsValid)
            {
                _service.CreateMovie(domainModel);
                return RedirectToAction("Overview");
            }
            return View(movieModel);
        }
        public IActionResult Delete(int id)
        {
            var response = _service.Delete(id);
            if (response.Success)
            {
                return RedirectToAction("ManageOverview", new { SuccessMessage = response.Message });
            }
            else
            {
                return RedirectToAction("ManageOverview", new { ErrorMessage = response.Message });
            }
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            try
            {
                var movie = _service.GetMovieById(id);
                return View(movie.ToUpdateMovieModel());
            }
            catch (MoviesException ex)
            {
                return RedirectToAction("ActionNotSuccessful", "Info", new { Message = ex.Message });
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorNotFound", "Info");
            }
        }
        [HttpPost]
        public IActionResult Update(UpdateMovieModel movieModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = _service.Update(movieModel.ToModel());
                    if (response.Success)
                    {
                        return RedirectToAction("ManageOverview", new { SuccessMessage = response.Message });
                    }
                    else
                    {
                        return RedirectToAction("ManageOverview", new { ErrorMessage = response.Message });
                    }
                }

                return View(movieModel);
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorNotFound", "Info");
            }
        }
        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            try
            {
                var movie = _service.GetMovieById(id);
                if (movie == null)
                {
                    return RedirectToAction("ErrorNotFound", "Info");
                }
                return View(movie.ToMovieDetailsModel());
            }
            catch (MoviesException ex)
            {
                return RedirectToAction("ActionNotSuccessful", "Info", new { Message = ex.Message });
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorNotFound", "Info");
            }
        }

    }
}
