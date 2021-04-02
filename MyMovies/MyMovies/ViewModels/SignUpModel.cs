using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.ViewModels
{
    public class SignUpModel
    {
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 3)]
        public string Lastname { get; set; }
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 3)]
        public string Address { get; set; }
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 3)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 8)]
        public string Username { get; set; }
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 8)]
        public string Password { get; set; }
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 8)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
