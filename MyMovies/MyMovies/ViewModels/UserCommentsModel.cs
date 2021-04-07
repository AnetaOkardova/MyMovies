using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.ViewModels
{
    public class UserCommentsModel
    {
        public string Message { get; set; }
        public DateTime DateCreated { get; set; }
        public string Username { get; set; }
    }
}
