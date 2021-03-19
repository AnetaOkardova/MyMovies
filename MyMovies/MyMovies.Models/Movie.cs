using System;
using System.ComponentModel.DataAnnotations;

namespace MyMovies.Models
{
    public class Movie
    {
       

        public int Id { get; set; }

        [Required(ErrorMessage ="This title is manually required :))")]
        [StringLength(maximumLength:50,MinimumLength =3)]
        public string Title { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public string ImageURL { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
    }
}
