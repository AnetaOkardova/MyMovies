using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMovies.Common.Exceptions;
using MyMovies.Common.Models;
using MyMovies.Common.Services;
using MyMovies.Mappings;
using MyMovies.Service;
using MyMovies.Services.Interfaces;
using MyMovies.ViewModels;
using System;
using System.Linq;

namespace MyMovies.Controllers
{
    [Authorize(Policy = "IsAdmin")]
    public class MoviesController : Controller
    {
        private readonly ISideBarService _sidebarService;
        private readonly IMovieGenresService _movieGenresService;
        private readonly ILogService _logService;
        private readonly IMoviesService _moviesService;

        public MoviesController(IMoviesService service, ISideBarService sidebarService, IMovieGenresService movieGenresService, ILogService logService)
        {
            _moviesService = service;
            _sidebarService = sidebarService;
            _movieGenresService = movieGenresService;
            _logService = logService;
        }
        [AllowAnonymous]
        public IActionResult Overview(string title)
        {
            try
            {
                var movies = _moviesService.GetMoviesWithFilters(title);
                var movieOverviewModel = movies.Select(x => x.ToMovieOverviewModel()).ToList();

                var movieOverviewDataModel = new MovieOverviewDataModel();
                movieOverviewDataModel.OverviewMovies = movieOverviewModel;

                movieOverviewDataModel.SidebarData = _sidebarService.GetSidebarData();

                return View(movieOverviewDataModel);
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
                var movies = _moviesService.GetAllMovies();
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
            var movieGenres = _movieGenresService.GetAll();
            var movieGenresToViewModel = movieGenres.Select(x => x.ToMovieGenresViewModel()).ToList();
            var movieViewModel = new CreateMovieModel();
            movieViewModel.MovieGenres = movieGenresToViewModel;
            return View(movieViewModel);
        }
        [HttpPost]
        public IActionResult Create(CreateMovieModel movieModel)
        {
            if (ModelState.IsValid)
            {
                var domainModel = movieModel.ToModel();
                var response = _moviesService.CreateMovie(domainModel);
                if (response.Success)
                {
                    var logData = new LogData() { Type = LogType.Info, DateCreated = DateTime.Now, Message = $"User with Id {User.FindFirst("Id")} created the movie with id {domainModel.Id} and title {domainModel.Title}" };
                    _logService.Log(logData);
                    return RedirectToAction("ManageOverview");
                }
                else
                {
                    return RedirectToAction("ManageOverview", new { ErrorMessage = response.Message });
                }
                
            }
            var movieGenres = _movieGenresService.GetAll();
            var movieGenresToViewModel = movieGenres.Select(x => x.ToMovieGenresViewModel()).ToList();
            movieModel.MovieGenres = movieGenresToViewModel;

            return View(movieModel);
        }
        public IActionResult Delete(int id)
        {
            var userId = Convert.ToInt32(User.FindFirst("Id").Value);
            var response = _moviesService.Delete(id, userId);
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
                var movie = _moviesService.GetMovieById(id);
                var movieGenres = _movieGenresService.GetAll();
                var movieGenresToViewModel = movieGenres.Select(x => x.ToMovieGenresViewModel()).ToList();
                var movieForView = movie.ToUpdateMovieModel();
                movieForView.MovieGenres = movieGenresToViewModel;
                return View(movieForView);
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
                    var userId = int.Parse(User.FindFirst("Id").Value);
                    var response = _moviesService.Update(movieModel.ToModel(), userId);
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
                var movie = _moviesService.GetMovieDetails(id);
                if (movie == null)
                {
                    return RedirectToAction("ErrorNotFound", "Info");
                }
                var logData = new LogData() { Type = LogType.Info, DateCreated = DateTime.Now, Message = $"User with Id {User.FindFirst("Id")} checked details for the movie with id {movie.Id} and title {movie.Title}" };
                _logService.Log(logData);
                var movieDetails = movie.ToMovieDetailsModel();

                movieDetails.SideBarModel = _sidebarService.GetSidebarData();

                return View(movieDetails);
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
