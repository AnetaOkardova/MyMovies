﻿using MyMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.ViewModels
{
    public class MovieOverviewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public string ImageURL { get; set; }
        public int Views { get; set; }
        public string Description { get; set; }
        public string MovieGenre { get; set; }
    }
}
