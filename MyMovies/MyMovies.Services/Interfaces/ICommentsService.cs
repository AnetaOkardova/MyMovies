using MyMovies.Services.DtoModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Services.Interfaces
{
    public interface ICommentsService
    {
        StatusModel Add(string comment, int movieId, int userId);
    }
}
