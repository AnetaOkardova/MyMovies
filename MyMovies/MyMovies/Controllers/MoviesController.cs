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
        public IActionResult Index()
        {

            //ViewBag.CurrentDate = DateTime.Now;
            //var a = 2;
            //var b = 3;
            //var sum = a + b;

            //ViewData["VarA"] = a;
            //ViewBag.VarA = a;
            //ViewBag.VarB = b;
            //ViewBag.Sum = sum;

            var movie = new Movie()
            {
                Id = 1,
                Title = "Home alone",
                Genre = "Comedy",
                Description = "Sth",
                Duration = 120,
                ImageURL = "https://m.media-amazon.com/images/M/MV5BMzFkM2YwOTQtYzk2Mi00N2VlLWE3NTItN2YwNDg1YmY0ZDNmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_.jpg",
            };
            var movie2 = new Movie()
            {
                Id = 2,
                Title = "Home alone",
                Genre = "Comedy",
                Description = "Sth",
                Duration = 120,
                ImageURL = "https://m.media-amazon.com/images/M/MV5BMzFkM2YwOTQtYzk2Mi00N2VlLWE3NTItN2YwNDg1YmY0ZDNmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_.jpg",
            };
            var movies = new List<Movie> { movie, movie2 };

            return View(movies);
        }
    }
}
