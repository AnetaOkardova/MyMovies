using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.ViewModels
{
    public class MovieLikeModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MovieId { get; set; }
    }
}
