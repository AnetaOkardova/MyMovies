using MyMovies.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.ViewModels
{
    public class CreateMovieModel
    {
        [Required(ErrorMessage = "This title is required :))")]
        [StringLength(maximumLength: 50, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public string ImageURL { get; set; }
        [Required]
        public int MovieGenreId { get; set; }
        public List<MovieGenresViewModel> MovieGenres { get; set; }
    }
}
