using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.ViewModels
{
    public class MovieDetailsModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int Duration { get; set; }

        public string ImageURL { get; set; }
    }
}
