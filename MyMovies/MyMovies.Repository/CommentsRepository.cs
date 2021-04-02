using MyMovies.Models;
using MyMovies.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Repository
{
    public class CommentsRepository : BaseRepository<Comment>, ICommentsRepository
    {
        public CommentsRepository(MyMoviesDbContext context) : base(context)
        {
        }
    }
}
