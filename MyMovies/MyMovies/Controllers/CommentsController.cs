using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMovies.Common.Exceptions;
using MyMovies.Services.Interfaces;
using MyMovies.ViewModels;
using System;
using MyMovies.Mappings;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.Controllers
{
    public class CommentsController : Controller
    {
        private ICommentsService _service { get; set; }
        public CommentsController(ICommentsService service)
        {
            _service = service;
        }
        [HttpPost]
        [Authorize]
        public IActionResult Add(string comment, int movieId)
        {
            var userId = int.Parse(User.FindFirst("Id").Value);
            var response = _service.Add(comment, movieId, userId);
            if (response.Success)
            {
                return RedirectToAction("Details", "Movies", new { id = movieId });
            }
            else
            {
                return RedirectToAction("ActionNotSuccessful", "Info", new { Message = response.Message });
            }
        }
        [Authorize]
        public IActionResult Delete(int id)
        {
            try
            {
                var userId = int.Parse(User.FindFirst("Id").Value);
                var commentId = id;
                var comment = _service.GetCommentById(id);
                var movieId = comment.MovieId;
                var response = _service.Delete(commentId, userId);
                if (response.Success)
                {
                    return RedirectToAction("Details", "Movies", new { id = movieId });
                }
                else
                {
                    return RedirectToAction("Overview", "Movies", new { ErrorMessage = response.Message });
                }
            }
            catch (MoviesException ex)
            {
                return RedirectToAction("ActionNotSuccessful", "Info", new { Message = ex.Message });
            }

        }
   
    }
}
