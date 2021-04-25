using MyMovies.Models;
using MyMovies.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMovies.Repository
{
    public class CommentsRepository : BaseRepository<Comment>, ICommentsRepository
    {
        public CommentsRepository(MyMoviesDbContext context) : base(context)
        {
        }

        public List<Comment> GetByMovieId(int id)
        {
            return _context.Comments.Where(x => x.MovieId == id).ToList();
        }

        public List<Comment> GetCommentByUserId(int id)
        {
            return _context.Comments.Where(x => x.UserId == id).ToList();
        }
    }
}
