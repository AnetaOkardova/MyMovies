﻿using Microsoft.AspNetCore.Mvc;
using MyMovies.Models;
using MyMovies.Services;
using MyMovies.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.Controllers
{
    public class MoviesController : Controller
    {
        private IMoviesService _service { get; set; }
        public MoviesController(IMoviesService service)
        {
            _service = service;
        }
        public IActionResult Details(int id)
        {
            var movie = _service.GetMovieById(id);
            if (movie == null)
            {
                return RedirectToAction("ErrorNotFound", "Info");
            }
            return View(movie);
        }
            
        public IActionResult Overview()
        {
            var movies = _service.GetAllMovies();
            return View(movies);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _service.CreateMovie(movie);
                return RedirectToAction("Overview");
            }
            return View(movie);
        }

    }
}
