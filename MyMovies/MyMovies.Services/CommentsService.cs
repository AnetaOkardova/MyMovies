using MyMovies.Repository.Interfaces;

namespace MyMovies.Services
{
    public class CommentsService
    {
        private readonly ICommentsRepository _commentsRepository;
        public CommentsService(ICommentsRepository commentsRepository)
        {
            _commentsRepository = commentsRepository;
        }

    }
}
