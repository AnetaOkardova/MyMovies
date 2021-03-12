using Microsoft.AspNetCore.Mvc;
using MyMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.Controllers
{
    public class MoviesController : Controller
    {
        public List<Movie> _movies { get; set; }
        public MoviesController()
        {
            var movie = new Movie()
            {
                Id = 1,
                Title = "Home alone",
                Genre = "Comedy",
                Description = "Sth",
                Duration = 100,
                ImageURL = "https://m.media-amazon.com/images/M/MV5BMzFkM2YwOTQtYzk2Mi00N2VlLWE3NTItN2YwNDg1YmY0ZDNmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_.jpg",
            };
            var movie2 = new Movie()
            {
                Id = 2,
                Title = "Home alone",
                Genre = "Comedy",
                Description = "Sth",
                Duration = 150,
                ImageURL = "https://m.media-amazon.com/images/M/MV5BMzFkM2YwOTQtYzk2Mi00N2VlLWE3NTItN2YwNDg1YmY0ZDNmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_.jpg",
            };
            _movies = new List<Movie> { movie, movie2 };
        }
        public IActionResult Details(int id)
        {
            var movie = _movies.FirstOrDefault(x => x.Id == id);
            if (movie == null)
            {
                return RedirectToAction("ErrorNotFound", "Info");
            }
            return View(movie);
        }
            
        public IActionResult Overview()
        {
            return View(_movies);
        }
    }
}
