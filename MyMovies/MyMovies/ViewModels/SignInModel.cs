using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.ViewModels
{
    public class SignInModel
    {
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 3)]
        public string Username { get; set; }
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 3)]
        public string Password { get; set; }
        public bool IsPersistent { get; set; }

    }
}
