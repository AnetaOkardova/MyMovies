using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyMovies.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 3)]
        public string Lastname { get; set; }
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 8)]
        public string Username { get; set; }
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 8)]
        public string Password { get; set; }
        [Required]
        public bool IsAdmin { get; set; }



    }
}
